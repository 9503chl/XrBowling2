using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XRInteraction : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject UI;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject sphere;
    [SerializeField] Material mat;

    bool Active1 = false;
    bool isNext = false;
    bool isblack = false;
    Color InputColor = new Color(0, 0, 0, 0);
    float alpha1 = 0;
    int count = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball")// 공 그랩시
        {
            Destroy(other.gameObject);
            UI.SetActive(false); //켜져있으면 끄기
            isNext = true;
            if (Active1 == true) Panel1.SetActive(false);
            GameObject.Find("Hand").SetActive(false);
        }
        if (other.transform.name == "Shoes")// 신발그랩시
        {
            Destroy(other.gameObject);
            UI.SetActive(false);
            isNext = true;
            if (Active1 == true) Panel1.SetActive(false);
            if (!isblack) isblack = true;
            GameObject.Find("Hand").SetActive(false);
        }
        if (other.transform.name == "Pinp") //핀 그랩시
        {
            Destroy(other.gameObject);
            count++;
            if (!Active1) //토글
            {
                Panel1.SetActive(true);
                Active1 = true;
            }
            else
            {
                Panel1.SetActive(false);
                Active1 = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if(isblack) InputColor = new Color(0, 0, 0, alpha1); //검정색으로 변환
        else InputColor = new Color(255, 255, 255, alpha1);
        if (isNext) //위치 고정
        {
            sphere.transform.position = mainCamera.transform.position;
            mat.color = InputColor;
            alpha1 += Time.deltaTime * 0.3f; //알파값 시간에 따라 증가
        }
        if (count == 10) //핀다쓸시 다시 생성
        {
            GameObject.Find("Magnet").GetComponent<MagnetMove>().count = 3;
            count = 0;
        }
        if (isblack && alpha1 >= 1.0f) Application.Quit();
        else if (alpha1 >= 1.0f) SceneManager.LoadScene("GameScene");
    }
}
