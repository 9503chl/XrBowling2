using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;

public class TitlePanel : View
{
    [SerializeField] private GameObject animationGroup;

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
        StartCoroutine(DelayedSetActive());
        ObjectManager.Instance.PinInteractiveOnOff(true);

        for(int i = 0; i <targetsOnOff.Length; i++)
        {
            targetsOnOff[i].SetActive(true);
        }
    }

    private void View_AfterShow()
    {

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
        animationGroup.SetActive(false);
        ObjectManager.Instance.PinInteractiveOnOff(false);

         for(int i = 0; i <targetsOnOff.Length; i++)
        {
            targetsOnOff[i].SetActive(false);
        }
    }

    private void View_AfterHide()
    {

    }
}