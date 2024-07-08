using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance;

    public List<InteractivePin> Pins = new List<InteractivePin>();

    public Shoes Shoes;

    public BowlingBall BowlingBall;

    private void Awake()
    {
        Instance = this;
    }

    public void PinInteractiveOnOff(bool isTrue)
    {
        for(int i = 0; i<Pins.Count; i++)
        {
            Pins[i].GetComponentInChildren<XRGrabInteractable>().enabled = isTrue;
        }
    }

    public void DelayedObjectOnOff(GameObject obj)
    {
        InteractiveObject interactiveObject = obj.GetComponent<InteractiveObject>();

        switch(interactiveObject.Type)
        {
            case InteractiveType.None: 

                break;
            case InteractiveType.Shoes: 
                
                break;
            case InteractiveType.BowlingBall: 
                
                break;
            case InteractiveType.Pin:
                StartCoroutine(ObjectDelayedRelease(0 , obj));
                break;
        }
    }

    private IEnumerator ObjectDelayedRelease(float time, GameObject target)
    {
        target.SetActive(false);

        yield return new WaitForSeconds(time);

        target.SetActive(true);
    }
    private IEnumerator ObjectDelayedRelease(float time, List <GameObject> targets)
    {
        for(int i = 0; i< targets.Count; i++)
        {
            targets[i].SetActive(false);
        }

        yield return new WaitForSeconds(time);

        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].SetActive(true);
        }
    }
}
