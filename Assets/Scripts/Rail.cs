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
            //bowlingBall._Rigidbody.ro ���� ȸ������ �˾Ƴ���, ȸ���� ���� �ִ� ����� �ֳ�?
            StartCoroutine(OiledRailCoroutine(bowlingBall.TargetVector, collision.gameObject.transform.rotation.z));
        }
    }
    private IEnumerator OiledRailCoroutine(Vector3 originTarget, float rotation)
    //Hand�� Ÿ�� �������̶�, �ӵ� ����ؼ� �ڷ�ƾ ��������, ȸ���� ������ �밢�� ������ ��̵�
    { 
        yield return null;

    }
}
