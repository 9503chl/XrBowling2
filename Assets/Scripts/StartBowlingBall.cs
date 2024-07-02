using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBowlingBall : InteractiveObject
{
    private void Awake()
    {
        Type = InteractiveType.StartBowling;
    }
    public override void Interaction()
    {
        BaseManager.Instance.ActiveView = ViewKind.Game;

        base.Interaction();
    }
}
