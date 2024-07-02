using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public enum InteractiveType
    {
        None = 0,
        StartingPin,
        GamePin,
        Shoes,
        StartBowling,
        GameBowling,
    }
    public InteractiveType Type = InteractiveType.None;

    public virtual void Interaction()
    {
        Debug.Log(string.Format("{0} Triggered", gameObject.name));

        ObjectManager.Instance.DelayedObjectOnOff(Type);
    }
}
