using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : View
{
    [NonSerialized]
    private Coroutine standByCoroutine;

    [SerializeField] private GameObject[] targetsOnOff;

    private void Awake()
    {
        OnBeforeShow += View_BeforeShow;
        OnAfterShow += View_AfterShow;
        OnBeforeHide += View_BeforeHide;
        OnAfterHide += View_AfterHide;
    }

    private void View_BeforeShow()
    {
        if(standByCoroutine  != null)
        {
            StopCoroutine(standByCoroutine);
            standByCoroutine = null;
        }
        standByCoroutine = StartCoroutine(Standby());
    }

    private void View_AfterShow()
    {
        PointManager.Instance.PinsParent.gameObject.SetActive(false);

        PointManager.Instance.MagnetFirstMove();

        for (int i = 0; i < targetsOnOff.Length; i++)
        {
            targetsOnOff[i].SetActive(true);
        }
    }

    private void View_BeforeHide()
    {
        PointManager.Instance.ScoreReset();


        for (int i = 0; i < targetsOnOff.Length; i++)
        {
            targetsOnOff[i].SetActive(false);
        }
    }

    private void View_AfterHide()
    {

    }

    private IEnumerator Standby()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(60f);

            BaseManager.Instance.ActiveView = ViewKind.Title;
        }
    }
}
