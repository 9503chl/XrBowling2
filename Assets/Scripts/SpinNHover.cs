using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using DG.Tweening;

public class SpinNHover : MonoBehaviour
{
    Vector3 prePos;
    Vector3 MovePos;
    Vector3 prePos1;
    Vector3 MovePos1;
    bool isdown = false;
    bool isdown1 = false;
    public bool isGrab = false;
    int speed = 2;
    int Angle = 0;
    void Start()
    {
        if(gameObject.name == "Shoes")
        {
            prePos = transform.position;
            MovePos = transform.position - new Vector3(0, 0.5f, 0);
        }
        else if (gameObject.tag == "Ball")
        {
            prePos1 = transform.position;
            MovePos1 = transform.position - new Vector3(0, 0.5f, 0);
        }
    }

    void FixedUpdate()
    {
        if (Angle >= 360) Angle = 0;
        Angle += 4;
        if (gameObject.name == "Shoes")
        {
            gameObject.transform.rotation = Quaternion.Euler(0, Angle, 0);
            if (!isdown)
            {
                if (Vector3.Distance(transform.position, MovePos) <= 0.1f) isdown = true;
                transform.position = Vector3.Lerp(transform.position, MovePos, speed * Time.deltaTime);

            }
            else
            {
                if (Vector3.Distance(transform.position, prePos) <= 0.1f) isdown = false;
                transform.position = Vector3.Lerp(transform.position, prePos, speed * Time.deltaTime);
            }
        }
        if (!isGrab) {
            gameObject.transform.rotation = Quaternion.Euler(0, Angle, 0);
            if (gameObject.tag == "Ball")
            {
                if (!isdown1)
                {
                    if (Vector3.Distance(transform.position, MovePos1) <= 0.1f) isdown1 = true;
                    transform.position = Vector3.Lerp(transform.position, MovePos1, speed * Time.deltaTime);

                }
                else
                {
                    if (Vector3.Distance(transform.position, prePos1) <= 0.1f) isdown1 = false;
                    transform.position = Vector3.Lerp(transform.position, prePos1, speed * Time.deltaTime);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        {
            if (other.transform.name == "BreakWall") GameObject.Find("Spawner").GetComponent<Ball>().isGone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
       if(other.transform.name == "RightHand Controller" && gameObject.tag == "Ball")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            isGrab = true;
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "RightHand Controller" && gameObject.tag == "Ball")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            isGrab = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "RightHand Controller" && gameObject.tag == "Ball")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            isGrab = true;
        }
    }
}
