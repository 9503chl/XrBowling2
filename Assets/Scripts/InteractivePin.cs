using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePin : InteractiveObject
{
    private Vector3 basePosition;

    private Quaternion baseRotation;

    private Rigidbody _rigidbody;

    public bool isDead;

    private void Awake()
    {
        Type = InteractiveType.Pin;

        _rigidbody = GetComponent<Rigidbody>();

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
    public void GravityOnOff(bool isTrue)
    {
        _rigidbody.useGravity = isTrue;
    }
    public override void ComponentOnOff(bool isTrue)
    {
        base.ComponentOnOff(isTrue);
        isDead = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Rail rail = other.GetComponent<Rail>();

        if(rail != null)
        {
            isDead = true;
        }
    }
}
