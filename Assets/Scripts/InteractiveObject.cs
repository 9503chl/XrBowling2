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

    public XRGrabInteractable grabInteractable;

    public virtual void OnAwake()
    {
        tweenRotation = GetComponentInChildren<TweenRotation>();
        tweenPosition = GetComponentInChildren<TweenPosition>();

        grabInteractable = GetComponentInChildren<XRGrabInteractable>();
    }

    public virtual void Interaction()
    {
        ObjectManager.Instance.DelayedObjectOnOff(gameObject);
    }

    public virtual void ComponentOnOff(bool isTrue)
    {
        if (tweenRotation!= null)
        {
            tweenRotation = GetComponentInChildren<TweenRotation>();

            tweenRotation.enabled = isTrue;
        }
        if (tweenPosition!= null)
        {
            tweenPosition = GetComponentInChildren<TweenPosition>();

            tweenPosition.enabled = isTrue;
        }
        if(grabInteractable!= null)
        {
            grabInteractable = GetComponentInChildren<XRGrabInteractable>();

            grabInteractable.enabled = isTrue;
        }
    }
}
