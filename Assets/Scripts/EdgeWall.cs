using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BowlingBall bowlingBall = collision.gameObject.GetComponent<BowlingBall>();
        if (bowlingBall != null)
        {
            StartCoroutine(DelayedComponentOn(bowlingBall));
        }

        InteractivePin pin = collision.gameObject.GetComponent<InteractivePin>();
        if(pin != null)
        {
            pin.gameObject.SetActive(false);
        }
    }
    IEnumerator DelayedComponentOn(BowlingBall bowlingBall)
    {
        yield return new WaitForSeconds(6.0f);

        bowlingBall.ComponentOnOff(true);

        PointManager.Instance.MagnetMove();
    }
}
