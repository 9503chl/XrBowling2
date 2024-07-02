using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractiveObject;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance;

    public List <InteractiveObject> StaringPins = new List <InteractiveObject> ();
    public List<InteractiveObject> GamePins = new List<InteractiveObject>();

    public InteractiveObject Shoes;
    public InteractiveObject StaringBowlingBalls;
    public InteractiveObject GameBowlingBalls;

    private void Awake()
    {
        Instance = this;
    }

    public void DelayedObjectOnOff(InteractiveType type)
    {
        switch(type)
        {
            case InteractiveType.None: 
                //StartCoroutine(ObjectDelayedRelease(3, ))
                break;
            case InteractiveType.Shoes: 
                
                break;
            case InteractiveType.StartBowling: 
                
                break;
            case InteractiveType.StartingPin: 
                
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
