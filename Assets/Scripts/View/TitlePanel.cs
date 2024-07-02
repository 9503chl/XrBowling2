using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;

public class TitlePanel : View
{
    [SerializeField] private GameObject animationGroup;
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
        DelayedFadeIn(FadeDuration);

        StartCoroutine(DelayedSetActive());
    }

    IEnumerator DelayedSetActive()
    {
        yield return new WaitForSeconds(FadeDuration);

        animationGroup.SetActive(true);
    }

    private void View_BeforeHide()
    {
        InfoManager infoManager = InfoManager.Instance;
        if (infoManager.isOn)
        {
            infoManager.InfoPanelOnOff();
        }
    }

    private void View_AfterHide()
    {

    }
}