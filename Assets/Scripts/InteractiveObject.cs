using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public InteractiveType Type = InteractiveType.None;

    public virtual void Interaction()
    {
        Debug.Log(string.Format("{0} Triggered", gameObject.name));

        ObjectManager.Instance.DelayedObjectOnOff(gameObject);
    }
}
