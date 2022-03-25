using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Vector3 prePos;
    Vector3 MovePos;
    bool isdown = false;
    int speed = 6;
    void Start()
    {
        prePos = transform.position;
        MovePos = transform.position - new Vector3(0, 0.6f, 0);
    }
    void FixedUpdate()
    {
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
}
