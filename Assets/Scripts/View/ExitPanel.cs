using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanel : View
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
        Application.Quit();

    }

    private void View_BeforeHide()
    {

    }

    private void View_AfterHide()
    {

    }
}
