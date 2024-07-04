using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using LitJson;

public enum ViewKind
{
    Title,
    Game,
    Exit,
    Size
}

public class BaseManager : MonoBehaviour
{
    public enum AvailableLanguage
    {
        Korean,
        English
    }

    [SerializeField]
    private AvailableLanguage language = AvailableLanguage.Korean;
    public AvailableLanguage Language
    {
        get
        {
            return language;
        }
        set
        {
            ApplyLanguage(value);
        }
    }

    [NonSerialized]
    private AvailableLanguage previousLanguage = AvailableLanguage.Korean;

    public event UnityAction OnChangeLanguage;

    [SerializeField]
    private SyncWebSocketClient WebSocketClient;

    [SerializeField]
    private TitlePanel titlePanel;

    [SerializeField]
    private GamePanel gamePanel;

    [SerializeField]
    private ExitPanel exitPanel;


    private static BaseManager instance;
    public static BaseManager Instance
    {
        get
        {
            if (instance == null)
            {
                BaseManager[] templates = FindObjectsOfType<BaseManager>(true);
                if (templates.Length > 0)
                {
                    instance = templates[0];
                    instance.enabled = true;
                    instance.gameObject.SetActive(true);
                }
            }
            return instance;
        }
    }

    [NonSerialized]
    private readonly Dictionary<ViewKind, View> views = new Dictionary<ViewKind, View>();

    [NonSerialized]
    private ViewKind activeView = ViewKind.Size;

    public ViewKind ActiveView
    {
        get
        {
            return activeView;
        }
        set
        {
            ChangeActiveView(value);
        }
    }

    private void Awake()
    {
        instance = this;

        // 시스템 설정을 로드
        if (!ProjectSettings.LoadFromXml())
        {
            ProjectSettings.SaveToXml();
        }

        // 모든 뷰를 딕셔너리에 넣은 후 숨김
        views.Add(ViewKind.Title, titlePanel);
        views.Add(ViewKind.Game, gamePanel);
        views.Add(ViewKind.Exit, exitPanel);

        foreach (KeyValuePair<ViewKind, View> view in views)
        {
            if (view.Value != null)
            {
                view.Value.SetActive(false);
            }
        }
    }

    private void Start()
    {
        if (WebSocketClient != null)
        {
            WebSocketClient.WebSocketURL = ProjectSettings.SignalWebSocketUrl;
            WebSocketClient.OnConnect += SignalWebSocketClient_OnConnect;
            WebSocketClient.OnDisconnect += SignalWebSocketClient_OnDisconnect;
            WebSocketClient.OnReceiveText += SignalWebSocketClient_OnReceiveText;
            WebSocketClient.Connect();
        }

        // 타이틀 화면에서 시작
        ChangeActiveView(ViewKind.Title);
        titlePanel.Show();

        StartCoroutine(Initialize());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveView = activeView++;
        }
    }
    private void SignalWebSocketClient_OnConnect()
    {
        
    }

    private void SignalWebSocketClient_OnDisconnect()
    {
       
    }

    private void SignalWebSocketClient_OnReceiveText(string message)
    {
       
    }


    private IEnumerator Initialize()
    {
        yield return null;

        if (WebSocketClient != null)
        {
            while (WebSocketClient.Connecting)
            {
                yield return null;
            }

            if (!WebSocketClient.Connected)
            {
                int boxID = MessageBox.Show("웹소켓 서버에 연결할 수 없습니다.", "프로그램 종료", "무시하고 진행", "오류", 0f, ApplicationQuit);
                while (!WebSocketClient.Connected)
                {
                    yield return null;
                }
                MessageBox.Close(boxID);
            }
        }
    }


    private void ApplicationQuit(bool isOK)
    {
        if (isOK)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    public void ChangeActiveView(ViewKind targetView)
    {
        if(targetView > ViewKind.Size)
        {
            targetView = 0;
        }
        if (activeView != targetView)
        {
            FadeManager.Instance.FadeInOut();
            if (views.ContainsKey(activeView))
            {
                views[activeView].Hide();
            }
            activeView = targetView;
            if (views.ContainsKey(targetView))
            {
                views[targetView].Show();
            }
        }
    }



#if UNITY_EDITOR
    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            if (previousLanguage != Language)
            {
                ApplyLanguage(Language);
            }
        }
    }
#endif

    private void ApplyLanguage(AvailableLanguage currentLanguage)
    {
        language = currentLanguage;
        if (previousLanguage != language)
        {
            SystemLanguage systemLanguage = SystemLanguage.Unknown;
            switch (language)
            {
                case AvailableLanguage.Korean:
                    systemLanguage = SystemLanguage.Korean;
                    break;
                case AvailableLanguage.English:
                    systemLanguage = SystemLanguage.English;
                    break;
            }
            TextAssetLoader[] textAssetLoaders = FindObjectsOfType<TextAssetLoader>();
            foreach (TextAssetLoader loader in textAssetLoaders)
            {
                loader.Language = systemLanguage;
            }
            SpriteLoader[] spriteLoaders = FindObjectsOfType<SpriteLoader>();
            foreach (SpriteLoader loader in spriteLoaders)
            {
                loader.Language = systemLanguage;
            }
            AudioClipLoader[] audioClipLoaders = FindObjectsOfType<AudioClipLoader>();
            foreach (AudioClipLoader loader in audioClipLoaders)
            {
                loader.Language = systemLanguage;
            }
            Debug.Log(string.Format("Language has changed : {0} -> {1}", previousLanguage, language));
            previousLanguage = language;
            if (OnChangeLanguage != null)
            {
                OnChangeLanguage.Invoke();
            }
        }
    }
}
