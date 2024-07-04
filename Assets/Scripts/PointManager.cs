using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;

    [SerializeField] private GameObject Magnet;
    [SerializeField] private GameObject Brush;
    [SerializeField] private GameObject PinOriginParent;
    
    private List<InteractiveObject> pins;

    private GameObject PinsParent;

    private Coroutine MagnetCor;
    private Coroutine BrushCor;

    private List<int[]> roundPoints = new List<int[]>();

    private int LastPang;

    private int totalPoint = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pins = ObjectManager.Instance.Pins;
        PinsParent = ObjectManager.Instance.PinsParent;
    }

    public void Strike()
    {

    }
    public void Spare()
    {

    }

    public void Score()
    {

    }


    public void MagnetMove()
    {
        if( MagnetCor == null ) 
            MagnetCor = StartCoroutine(IMagentMove());

        //아이디어 : 마그넷 아래로 내려와서, SetParent 한 후 같이 움직이기.
    }

    private IEnumerator IMagentMove()
    {
        yield return null;
        MagnetCor = null;
    }

    public void BrushMove()
    {
        if(BrushCor == null) 
            BrushCor = StartCoroutine(IBrushMove());
    }
    private IEnumerator IBrushMove()
    {
        yield return null;
        BrushCor = null;
    }

    public void ScoreReset()
    {
        roundPoints.Clear();
        totalPoint = 0;
    }
}
