using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InteractiveObject interactiveObj = other.GetComponent<InteractiveObject>();
        if(interactiveObj != null)
        {
            interactiveObj.Interaction();
            interactiveObj.ComponentOnOff(false);
        }
    }
}
