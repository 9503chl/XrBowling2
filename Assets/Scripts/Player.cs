using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InteractiveObject obj = other.GetComponent<InteractiveObject>();
        if(obj != null)
        {
            obj.Interaction();
        }
    }
}
