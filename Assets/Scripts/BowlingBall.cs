using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BowlingBall : InteractiveObject
{
    public Vector3 TargetVector;

    public Rigidbody _Rigidbody;

    private void Awake()
    {
        Type = InteractiveType.BowlingBall;

        _Rigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void Start()
    {
        OnAwake();
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
            _Rigidbody.useGravity = true;

            base.ComponentOnOff(false);
        }
    }
}
