using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUp : MonoBehaviour
{
    Vector3 pos1;
    Vector3 pos2;
    Rigidbody rg;

    bool rotate = false;
#if UNITY_EDITOR
    int speed = 60;
#else 
    int speed = 6;
#endif
    void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position - new Vector3(0, 0.55f, 0);
        rg = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (gameObject.transform.rotation.eulerAngles.x > 330 || gameObject.transform.rotation.eulerAngles.x < 7.5)
        { 
            rg.useGravity = true; gameObject.GetComponent<Rigidbody>().isKinematic = false; 
            GameObject.Find("Score").GetComponent<Score>().sCount++;
            gameObject.GetComponent<PinUp>().enabled = false;
        }
        if (!GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && GameObject.Find("Magnet").GetComponent<MagnetMove>().Twice) //¾÷
        {
            Invoke("RotateFix", 1.0f);
            if (GameObject.Find("BreakWall").GetComponent<DesPin>().isCollide)
            {
                pos1 = transform.position + new Vector3(0, 0.65f, 0); pos2 = transform.position;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isCollide = false;
            }
            if (rotate)
            {
                gameObject.transform.localEulerAngles = new Vector3(270, 0, 0);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            Invoke("SecondM", 1.0f); rg.useGravity = false;
        }
        if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && GameObject.Find("Magnet").GetComponent<MagnetMove>().count !=4) //´Ù¿î
        {
            rg.useGravity = false; gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Invoke("FirstM", 0.5f); Invoke("GravityOn", 1.2f);
        }
        if(GameObject.Find("Magnet").GetComponent<MagnetMove>().count == 4)
        {
            Invoke("FirstM", 0.5f); Invoke("GravityOn", 1.2f);
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, pos2, speed * Time.deltaTime);
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, pos1, speed * Time.deltaTime);
    }
    void GravityOn()
    {
        rg.useGravity = true;
    }
    void RotateFix()
    {
        rotate = true;
    }
}
