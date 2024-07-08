using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEditor;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private Material fadeMat;

    [SerializeField] private float speed;

    public static FadeManager Instance;

    public List<GameObject> TargetOffs;

    private bool isFadeInOut;
    
    private Coroutine FadeInOutCor;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        fadeMat.color = Color.black;
    }
    public bool FadeInOut()
    {
        isFadeInOut = true;
        if(FadeInOutCor == null)
        {
            FadeInOutCor = StartCoroutine(IFadeInOut());
        }
        return isFadeInOut;
    }
    IEnumerator IFadeInOut()
    { 
        for (int i = 0; i < TargetOffs.Count; i++)
        {
            TargetOffs[i].SetActive(false);
        }

        fadeMat.DOColor(Color.black, speed);

        yield return new WaitForSeconds(speed);

        fadeMat.DOFade(0, speed);

        yield return new WaitForSeconds(speed);

        for (int i = 0; i < TargetOffs.Count; i++)
        {
            TargetOffs[i].SetActive(true);
        }
        isFadeInOut = false;

        FadeInOutCor = null;
    }
}
