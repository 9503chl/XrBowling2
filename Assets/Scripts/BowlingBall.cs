using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BowlingBall : InteractiveObject
{
    public Rigidbody _Rigidbody;
    public float Speed;
    private void Awake()
    {
        Type = InteractiveType.BowlingBall;

        _Rigidbody = GetComponentInChildren<Rigidbody>();
    }
    public override void Interaction()
    {
        if(BaseManager.Instance.ActiveView == ViewKind.Title)
        {
            BaseManager.Instance.ActiveView = ViewKind.Game;

            base.Interaction();
        }
        else
        {
            ComponentOnOff(false);
        }
    }
}
