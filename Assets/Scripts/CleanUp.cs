using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    bool Once1 = true, Once2 = false, Once3 = false;
    public bool isDone = false;

#if UNITY_EDITOR
    int speed1 = 100;
    int speed2 = 80;
#else 
    int speed1 = 10;
    int speed2 = 8;
#endif
    void FixedUpdate()
    { 
        if (GameObject.Find("Magnet").GetComponent<MagnetMove>().isMagnetMove) 
        {
            if (Once1) Invoke("FirstM", 0.5f);
            if (Vector3.Distance(gameObject.transform.position, Target1.transform.position) <= 0.05f)
            {
                Once1 = false; Once2 = true;
                Invoke("SecondM", 1.0f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target2.transform.position) <= 0.05f && Once2)
            {
                Once3 = true;
                Invoke("ThirdM", 1.2f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target3.transform.position) <= 0.05f && Once3)
            {
                GameObject.Find("Magnet").GetComponent<MagnetMove>().isMagnetMove = false;
                Once1 = true; Once2 = false; Once3 = false; isDone = true;
            }
        }
        if (GameObject.Find("Magnet").GetComponent<MagnetMove>().count == 2) //두번째 시퀀스
        {
            if (Once1) Invoke("FirstM", 0.5f);
            if (Vector3.Distance(gameObject.transform.position, Target1.transform.position) <= 0.05f)
            {
                Once1 = false; Once2 = true;
                Invoke("SecondM", 1.0f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target2.transform.position) <= 0.05 && Once2)
            {
                Once3 = true;
                Invoke("ThirdM", 1.2f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target3.transform.position) <= 0.05f && Once3)
            {
                Once1 = true; Once2 = false; Once3 = false;
                GameObject.Find("Magnet").GetComponent<MagnetMove>().count++;
            }
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, Target1.position, speed1 * Time.deltaTime * 0.7f);
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, Target2.position, speed2 * Time.deltaTime * 0.7f);
    }
    void ThirdM()
    {
        transform.position = Vector3.Lerp(transform.position, Target3.position, speed1 * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Pin") Destroy(collision.gameObject);
    }
}