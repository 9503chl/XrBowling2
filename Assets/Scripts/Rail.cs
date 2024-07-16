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
            //bowlingBall._Rigidbody.ro 현재 회전력을 알아내서, 회전에 가속 넣는 방법이 있나?
            StartCoroutine(OiledRailCoroutine(bowlingBall.TargetVector, collision.gameObject.transform.rotation.z));
        }
    }
    private IEnumerator OiledRailCoroutine(Vector3 originTarget, float rotation)
    //Hand에 타겟 포지션이랑, 속도 계산해서 코루틴 돌려야함, 회전이 있으면 대각선 배지어 곡선이동
    { 
        yield return null;

    }
}
