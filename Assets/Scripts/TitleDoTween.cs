using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TitleDoTween : MonoBehaviour
{
    [SerializeField]AudioSource shotGunSound;
    [SerializeField] AudioSource BarrelblowSound;
    [SerializeField] GameObject Pointer;
    CameraShake Camera;
    public bool DoTweenDone = false;
    void Start()
    {
        Camera = GameObject.Find("XR Rig").GetComponent<CameraShake>();
        if (gameObject.name == "X")
        {
            Invoke("doTween", 0.5f);
        }
        if (gameObject.name == "R")
        {
            Invoke("doTween", 0.9f);
        }
        if (gameObject.name == "B")
        {
            Invoke("doTween", 1.3f);
        }
        if (gameObject.name == "O")
        {
            Invoke("doTween", 1.7f);
        }
        if (gameObject.name == "W")
        {
            Invoke("doTween", 2.1f);
        }
        if (gameObject.name == "L")
        {
            Invoke("doTween", 2.5f);
        }
        if (gameObject.name == "I")
        {
            Invoke("doTween", 2.9f);
        }
        if (gameObject.name == "N")
        {
            Invoke("doTween", 3.3f);
        }
        if (gameObject.name == "G")
        {
            Invoke("doTween", 3.7f);
        }
        if (gameObject.tag == "XRBOWLING")
        {
            Invoke("doTweenForward", 4.2f);
            Invoke("Counter", 4.8f);
        }
    }

    void doTween()
    {
        transform.DOScale(new Vector3(1,1,1), 0.5f);
        transform.DOMoveZ((transform.position.x + 200), 0.2f);
        Invoke("Disabler", 0.2f);
        shotGunSound.Play();
        Camera.VibrateForTime(0.4f);
    }
    void doTweenForward()
    {
        transform.DOMoveX((transform.position.x - 500), 0.2f);
        transform.DOMoveY((transform.position.y - 500), 0.2f);
        Camera.VibrateForTime(0.6f);
        BarrelblowSound.Play();
    }
    void Disabler()
    {
        gameObject.SetActive(false);
    }
    void Counter()
    {
        GameObject.Find("Magnet").GetComponent<MagnetMove>().count = 3;
        DoTweenDone = true;
        Pointer.SetActive(true);
    }
}
