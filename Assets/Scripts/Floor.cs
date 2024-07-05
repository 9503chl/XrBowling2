using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        InteractiveObject interactiveObject = collision.gameObject.GetComponent<InteractiveObject>();
        if(interactiveObject != null )
        {
            StartCoroutine(DelayedComponentOn(interactiveObject));
        }
    }
    IEnumerator DelayedComponentOn(InteractiveObject interactiveObject)
    {
        yield return new WaitForSeconds(1.5f);

        interactiveObject.ComponentOnOff(true);
    }
}
