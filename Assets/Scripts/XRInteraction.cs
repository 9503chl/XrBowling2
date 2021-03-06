using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInteraction : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject UI;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject sphere;
    [SerializeField] Material mat;
    [SerializeField] GameObject LeftHand;
    [SerializeField] GameObject Hand;
    float mouseX = 0;
    bool Active1 = false;
    bool isNext = false;
    bool isblack = false;
    Color InputColor = new Color(0, 0, 0, 0);
    float alpha1 = 0;
    int count = 0;
    void Update()
    {
        Rotate();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball")// ?? ?׷???
        {
            Destroy(other.gameObject);
            UI.SetActive(false); //?????????? ????
            isNext = true;
            if (Active1 == true) Panel1.SetActive(false);
            Hand.SetActive(false);
            LeftHand.SetActive(false);
            gameObject.GetComponent<XRInteractorLineVisual>().enabled = false;
        }
        if (other.transform.name == "Shoes")// ?Ź߱׷???
        {
            Destroy(other.gameObject);
            UI.SetActive(false);
            isNext = true;
            if (Active1 == true) Panel1.SetActive(false);
            if (!isblack) isblack = true;
            Hand.SetActive(false);
            LeftHand.SetActive(false);
            gameObject.GetComponent<XRInteractorLineVisual>().enabled = false;
        }
        if (other.transform.name == "Pinp") //?? ?׷???
        {
            Destroy(other.gameObject);
            count++;
            if (!Active1) //????
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
    void Rotate()
    {
        mouseX += Input.GetAxis("Mouse X") * 10;
        mainCamera.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
    private void FixedUpdate()
    {
        if(isblack) InputColor = new Color(0, 0, 0, alpha1); //?????????? ??ȯ
        else InputColor = new Color(255, 255, 255, alpha1);
        if (isNext) //??ġ ????
        {
            sphere.transform.position = mainCamera.transform.position;
            mat.color = InputColor;
            alpha1 += Time.deltaTime * 0.3f; //???İ? ?ð??? ???? ????
        }
        if (count == 10) //?ɴپ??? ?ٽ? ????
        {
            GameObject.Find("Magnet").GetComponent<MagnetMove>().count = 3;
            count = 0;
        }
        if (isblack && alpha1 >= 1.0f) Application.Quit();
        else if (alpha1 >= 1.0f) SceneManager.LoadScene("GameScene");
    }
}
