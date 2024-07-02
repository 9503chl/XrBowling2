using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePin : InteractiveObject
{
    private void Awake()
    {
        Type = InteractiveType.StartingPin;
    }
    public override void Interaction()
    {
        InfoManager.Instance.InfoPanelOnOff();

        base.Interaction();
    }
}
