using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetMove : MonoBehaviour
{
    public Transform Target4;
    public Transform Target5;
    public Transform spawnTr;
    public GameObject Pin;
    GameObject pinClone;

    bool Once = true;
    public bool isMagnetMove = false, Twice = false;

    public int count = 0;

#if UNITY_EDITOR
    int speed = 60;
#else 
    int speed = 6;
#endif
    void FixedUpdate()
    {
        if (GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst && count < 2) //첫번째
        {
            if (Once) Invoke("FirstM", 0.5f);
            if (Vector3.Distance(gameObject.transform.position, Target4.transform.position) <= 0.05f)
            {
                Invoke("SecondM", 1.0f); Once = false; Twice = true;
            }
            if (Vector3.Distance(gameObject.transform.position, Target5.transform.position) <= 0.05f && Twice)
            {
                isMagnetMove = true;
                Once = true; Twice = false;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
            }      
        }

        if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && count < 2) //두번째
        {
            if (Once) Invoke("FirstM", 0.5f);
            if (Vector3.Distance(gameObject.transform.position, Target4.transform.position) <= 0.05f)
            {
                Invoke("SecondM", 1.0f); Once = false; Twice = true;
            }
            if (Vector3.Distance(gameObject.transform.position, Target5.transform.position) <= 0.05f && Twice)
            {
                Once = true; Twice = false;
                GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone = false;
            }
        }
        if(count == 3)
        {
            Destroy(GameObject.FindWithTag("Pin")); //이전거 삭제
            GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone = true;
            count++;
        }
        if(count == 4) //핀 다지워지고
        {
            if (GameObject.FindWithTag("Pin") == null)
            {
                Instantiate(Pin, spawnTr.position, spawnTr.rotation); //3으로 시작할땐 스폰이됨
                pinClone = GameObject.FindWithTag("Pin"); 
            }
            if (Once) Invoke("FirstM", 0.4f);
            if (Vector3.Distance(gameObject.transform.position, Target4.transform.position) <= 0.05f)
            {
                Invoke("SecondM", 1.0f); Once = false; Twice = true;
            }
            if (Vector3.Distance(gameObject.transform.position, Target5.transform.position) <= 0.05f && Twice)
            {
                Once = true; Twice = false; count = 0;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
                GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone = false;
            }
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, Target4.position, speed * Time.deltaTime);
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, Target5.position, speed * Time.deltaTime);
    }
}
