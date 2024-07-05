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
    [SerializeField] private GameObject PinOriginParent;
    
    private List<InteractivePin> pins;

    private GameObject PinsParent;

    private Coroutine MagnetCor;

    private int currentRound = 0;

    private List<List<int>> roundPoints = new List<List<int>> ();

    public int TotalPoint = 0;//총 점수

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pins = ObjectManager.Instance.Pins;
        PinsParent = ObjectManager.Instance.PinsOriginParent;
    }

    public void Strike()
    {
        //계산 해야함.

        BoardAppear();
    }
    public void Spare()
    {
        //계산 해야함.
        
        BoardAppear();
    }

    public void Score(int point)
    {
        roundPoints[currentRound].Add(point);

        TotalPoint += point;

        BoardAppear();
    }
    public void BoardAppear()
    {

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

        if (roundPoints[currentRound].Count == 1)
        {
            if (point + roundPoints[currentRound][0] == 10)
            {
                Spare();
            }
            else
            {
                Score(point);
            }

            StartCoroutine(SpareOrStrikeCommonCor());
        }

        else if (point == 10)
        {
            Strike();

            StartCoroutine(SpareOrStrikeCommonCor());
        }

        else
        {
            Score(point);

            for (int i = 0; i < pins.Count; i++)
            {
                if (!pins[i].isDead)
                {
                    pins[i].GravityOnOff(false);
                }
            }

            Magnet.transform.DOMoveY(0.2f, 0.75f);

            yield return new WaitForSeconds(0.75f);

            pins[0].transform.parent.transform.SetParent(Magnet.transform);

            Magnet.transform.DOMoveY(0.8f, 0.75f);

            yield return new WaitForSeconds(0.75f);

            yield return StartCoroutine(IBrushMove());

            Magnet.transform.DOMoveY(0.2f, 0.75f);

            yield return new WaitForSeconds(0.75f);

            pins[0].transform.parent.transform.SetParent(PinsParent.transform);

            for (int i = 0; i < pins.Count; i++)
            {
                pins[i].GravityOnOff(true);
            }

            Magnet.transform.DOMoveY(0.8f, 0.75f);
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

        pins[0].transform.parent.transform.SetParent(Magnet.transform);

        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].gameObject.SetActive(true);
        }

        Magnet.transform.DOMoveY(0.2f, 0.75f);

        yield return new WaitForSeconds(0.75f);

        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].GravityOnOff(true);
        }

        pins[0].transform.parent.transform.SetParent(PinsParent.transform);

        Magnet.transform.DOMoveY(0.8f, 0.75f);
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
 