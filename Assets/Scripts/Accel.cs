using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accel : MonoBehaviour
{
    [SerializeField]GameObject mainCam;
    float power;
    private Transform tr;
    public bool isMove = false;
    public float speed = 0.0f;
    float spin = 0;
    public int Angle = 0;
    public float time = 0.0f;
    bool once = false;
    void Awake()
    {
        tr = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (isMove)
        {
            if (!once) 
            {
                mainCam.SetActive(false);
                GameObject.Find("Spawner").GetComponent<Ball>().viewCamera.SetActive(true);
                once = true;
            }
            GameObject.Find("Spawner").GetComponent<Ball>().viewCamera.transform.position = gameObject.transform.position + new Vector3(0, 0.2f, -0.1f);
            GameObject.Find("Main Camera").transform.rotation = Quaternion.Euler(0,0,0);
            time += Time.deltaTime; //움직인 시간
            Angle += 30;
            speed = power;
            if (Angle >= 360) Angle = 0;
            if (GameObject.Find("hall").GetComponent<Dump>().dumpCount == 0 && GameObject.Find("hall2").GetComponent<Dump>().dumpCount == 0) //도착까지 2.5초
            {
                if (speed <= -0.15f) //오 회전
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, -Angle);
                else if (speed >= 0.15f) //왼 회전
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, Angle);
                else // 무회전
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, 0);
                if (time <= 1.2f) //대각선 이동
                {
                    tr.transform.Translate(new Vector3(speed * 0.3f, 0, 0.6f) * Time.deltaTime * 5.0f, Space.World);
                }
                else if (time <= 3.5f) //회전이 천천히 걸림
                {
                    spin += Time.deltaTime;
                    tr.transform.Translate(new Vector3(-speed * spin * 0.5f, 0, 0.6f) * Time.deltaTime * 5.0f, Space.World);
                }
            }
            else //덤에 빠졌을때 직선운동
            {
                tr.transform.Translate(Vector3.forward * 0.6f * Time.deltaTime * 5.0f, Space.World);
                tr.transform.rotation = Quaternion.Euler(Angle, 0, 0);
            }
        }
        else
        {
            power = GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().power;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            isMove = true;
            GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isMove = true;
            GameObject.Find("Spawner").GetComponent<Ball>().isRoll = true;
        }
    }
}