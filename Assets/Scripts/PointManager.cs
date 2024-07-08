using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;

    [SerializeField] private GameObject Magnet;
    [SerializeField] private GameObject Brush;

    [SerializeField] private Board board;
    
    private List<InteractivePin> pins;

    public GameObject PinParentTarget;

    public Transform PinsParent;

    private Coroutine MagnetCor;

    private bool isSpare;
    private bool isStrike;

    private int currentRound = 0;
    public int TotalPoint = 0;

    private List<List<int>> roundPoints = new List<List<int>>();

    public float Speed;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pins = ObjectManager.Instance.Pins;

        PinsParent = pins[0].transform.parent.parent;
    }


    private void Score(int point)
    {
        roundPoints[currentRound].Add(point);

        TotalPoint += point;

        BoardAppear();
    }
    private void BoardAppear()
    {
        board.TextInit(roundPoints);
    }
    public void MagnetFirstMove()
    {
        StartCoroutine(FirstMagnetMove());
    }

    private IEnumerator FirstMagnetMove()
    {
        PinsParent.gameObject.SetActive(true);

        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].GravityOnOff(false);
        }

        PinsParent.SetParent(Magnet.transform);

        Magnet.transform.DOMoveY(0.2f, Speed);

        yield return new WaitForSeconds(Speed + 0.5f);

        PinsParent.SetParent(PinParentTarget.transform);

        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].GravityOnOff(true);
        }

        Magnet.transform.DOMoveY(0.8f, Speed);
    }

    public void MagnetMove()
    {
        if(MagnetCor == null) 
            MagnetCor = StartCoroutine(IMagentMove());
    }
    private IEnumerator IMagentMove()
    {
        int point = 0;

        for (int i = 0; i < pins.Count; i++)
        {
            if (pins[i].isDead) point++;
        }

        if (isSpare)
        {
            isSpare = false;

            TotalPoint += point;
        }
        if (isStrike)
        {
            TotalPoint += point;
        }

        Score(point);

        if (roundPoints[currentRound].Count == 1)
        {
            isStrike = false;

            if (point + roundPoints[currentRound][0] == 10)
            {
                isSpare = true;
            }

            currentRound++;

            StartCoroutine(SpareOrStrikeCommonCor());
        }

        else if (point == 10)
        {
            isStrike = true;

            StartCoroutine(SpareOrStrikeCommonCor());
        }

        else//아직 10라운드 스페어 처리하면 추가 기회주는거 안 만듦
        {
            Score(point);

            for (int i = 0; i < pins.Count; i++)
            {
                if (!pins[i].isDead)
                {
                    pins[i].GravityOnOff(false);
                }
            }

            PinsParent.SetParent(Magnet.transform);

            Magnet.transform.DOMoveY(0.2f, Speed);

            yield return new WaitForSeconds(Speed + 0.5f);

            Magnet.transform.DOMoveY(0.8f, Speed);

            yield return new WaitForSeconds(Speed);

            yield return StartCoroutine(IBrushMove());

            Magnet.transform.DOMoveY(0.2f, Speed);

            yield return new WaitForSeconds(Speed);

            PinsParent.SetParent(PinParentTarget.transform);

            for (int i = 0; i < pins.Count; i++)
            {
                if (!pins[i].isDead)
                    pins[i].GravityOnOff(true);
            }

            Magnet.transform.DOMoveY(0.8f, Speed);
        }

        MagnetCor = null;
    }
    private IEnumerator SpareOrStrikeCommonCor()
    {
        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].GravityOnOff(false);
        }

        yield return StartCoroutine(IBrushMove());

        PinsParent.SetParent(Magnet.transform);

        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].gameObject.SetActive(true);
        }

        Magnet.transform.DOMoveY(0.2f, Speed);

        yield return new WaitForSeconds(Speed + 0.5f);

        PinsParent.SetParent(PinParentTarget.transform);

        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].GravityOnOff(true);
        }

        Magnet.transform.DOMoveY(0.8f, Speed);
    }

    private IEnumerator IBrushMove()
    {
        Brush.transform.DOLocalMoveY(0.225f, 0.5f);

        yield return new WaitForSeconds(0.5f);

        Brush.transform.DOLocalMoveZ(8, 0.75f);

        yield return new WaitForSeconds(0.75f);

        Brush.transform.DOLocalMove(new Vector3(0, 0.825f, 5.5f), 0.5f);
    }

    public void ScoreReset()
    {
        roundPoints.Clear();

        TotalPoint = 0;
    }
}
 