using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSound : MonoBehaviour
{
    [SerializeField] AudioSource pinSound;

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Ball")
        {
            pinSound.Play();
        }
    }
}
