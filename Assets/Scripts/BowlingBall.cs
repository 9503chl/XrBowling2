using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : InteractiveObject
{
    private void Awake()
    {
        Type = InteractiveType.BowlingBall;
    }
    public override void Interaction()
    {
        BaseManager.Instance.ActiveView = ViewKind.Game;

        base.Interaction();
    }
}
