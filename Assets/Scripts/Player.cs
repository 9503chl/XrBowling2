using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ThrowingTarget _ThrowingTarget;
    private void Awake()
    {
        _ThrowingTarget = GetComponent<ThrowingTarget>();
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractiveObject interactiveObj = other.GetComponent<InteractiveObject>();
        if(interactiveObj != null)
        {
            interactiveObj.Interaction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BowlingBall bowlingBall = other.GetComponent<BowlingBall>();
        if(bowlingBall != null)
        {
            bowlingBall.TargetVector = _ThrowingTarget.transform.position;
        }
    }
}
