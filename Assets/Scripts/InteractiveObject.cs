using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractiveObject : MonoBehaviour
{
    public InteractiveType Type = InteractiveType.None;

    private TweenRotation tweenRotation;
    private TweenPosition tweenPosition;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        tweenRotation = GetComponent<TweenRotation>();
        tweenPosition = GetComponent<TweenPosition>();
        
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public virtual void Interaction()
    {
        Debug.Log(string.Format("{0} Triggered", gameObject.name));

        ObjectManager.Instance.DelayedObjectOnOff(gameObject);
    }

    public virtual void ComponentOnOff(bool isTrue)
    {
        tweenRotation.enabled = isTrue;
        tweenPosition.enabled = isTrue;
        grabInteractable.enabled = isTrue;
    }
}
