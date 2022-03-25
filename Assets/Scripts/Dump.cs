using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dump : MonoBehaviour
{
    public int dumpCount = 0;
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball") dumpCount++;
    }
}