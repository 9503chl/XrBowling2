using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BowlingBall bowlingBall = collision.gameObject.GetComponentInChildren<BowlingBall>();
        if(bowlingBall != null)
        {
            bowlingBall._Rigidbody.AddForce(bowlingBall.transform.forward, ForceMode.Acceleration);
        }
    }
}
