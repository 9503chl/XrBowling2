using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePin : InteractiveObject
{
    private Vector3 basePosition;
    private Quaternion baseRotation;
    private void Awake()
    {
        Type = InteractiveType.Pin;
        basePosition = transform.position;
        baseRotation = transform.rotation;
    }
    private void OnEnable()
    {
        transform.position = basePosition;
        transform.rotation = baseRotation;
    }
    public override void Interaction()
    {
        InfoManager.Instance.InfoPanelOnOff();

        base.Interaction();
    }
}
