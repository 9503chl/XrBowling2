using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InteractiveObject interactiveObj = other.GetComponent<InteractiveObject>();
        if(interactiveObj != null)
        {
            interactiveObj.Interaction();
        }
    }
}
