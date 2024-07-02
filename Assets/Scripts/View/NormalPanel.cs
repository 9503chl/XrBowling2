using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NormalPanel : View
{
    private void Awake()
    {
        OnBeforeShow += View_BeforeShow;
        OnAfterShow += View_AfterShow;
        OnBeforeHide += View_BeforeHide;
        OnAfterHide += View_AfterHide;
    }

    private void View_BeforeShow()
    {
    }

    private void View_AfterShow()
    {
        Hide();
    }

    private void View_BeforeHide()
    {

    }

    private void View_AfterHide()
    {
       
    }

    private IEnumerator Standby()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
        }
    }
}
