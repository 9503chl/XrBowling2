using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : View
{
    [NonSerialized]
    private Coroutine standByCoroutine;

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
        DelayedFadeIn(FadeDuration);
    }

    private void View_BeforeHide()
    {

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
