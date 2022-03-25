using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject sBall;
    [SerializeField] AudioSource ballSound;
    public GameObject viewCamera;
    public bool isGone = false;
    public bool isRoll = false;
    private void Start()
    {
        viewCamera = GameObject.Find("View Camera");
        viewCamera.SetActive(false);
    }
    private void Update()
    {
        if (isGone) //공이랑 breakwall이 충돌시
        {
            ballSound.Stop();
            Invoke("Spawner1",4.5f);
            isGone = false; isRoll = false;
        }
        if (isRoll)
        {
            ballSound.Play();
            isRoll = false;
        }
    }
    void Spawner1()
    {
        Instantiate(sBall, gameObject.transform.position, gameObject.transform.rotation);
    }
}
