using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera viewCamera;
    [SerializeField] Material mat;


    float alpha1 = 0;
    public bool isNext = false;
    Color InputColor = new Color(0, 0, 0, 0);
    public bool isLeft = false;
    public bool isRight = false;
    public bool isNormal = false;
    public bool isMove = false;
    public float power = 0;

    private void FixedUpdate()
    {
        power = gameObject.transform.rotation.z;
        InputColor = new Color(0, 0, 0, alpha1);
        if (power >= 0.15)
        {
            isRight = false;
            isLeft = true;
            isNormal = false;
        }
        else if (power <= -0.15)
        {
            isRight = true;
            isLeft = false;
            isNormal = false;
        }
        else
        {
            isRight = false;
            isLeft = false;
            isNormal = true;
        }
        if (isNext)
        {
            sphere.transform.position = mainCamera.transform.position;
            mat.color = InputColor;
            alpha1 += Time.deltaTime * 0.3f; //알파값 시간에 따라 증가
        }
        if (alpha1 >=1.0f) SceneManager.LoadScene("TitleScene");
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Shoes")
        {
            Destroy(other.gameObject);
            GameObject.Find("Hand").SetActive(false);
            Destroy(viewCamera);
            isNext = true;

        }
    }
}