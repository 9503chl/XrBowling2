using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : InteractiveObject
{
    private void Awake()
    {
        Type = InteractiveType.Shoes;
    }
    public override void Interaction()
    {
        BaseManager baseManager = BaseManager.Instance;

        if(baseManager.ActiveView == ViewKind.Title)
        {
            baseManager.ActiveView = ViewKind.Exit;
        }
        else
        {
            baseManager.ActiveView = ViewKind.Title;
        }
        base.Interaction();

    }
}
