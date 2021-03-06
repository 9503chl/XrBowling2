using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DesPin : MonoBehaviour
{
    [SerializeField] GameObject mainCam;
    [SerializeField] Material ScoreMat;
    public GameObject viewCam;
    public bool isFirst = false;
    public bool isCollide = false;
    public bool isStart = false;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isFirst = true;
            Invoke("isCollideM", 1.2f);
            Invoke("tCountUp", 1.0f); //세는 시간을 주자
            Invoke("isMoveOff", 1.5f);
            viewCam.transform.position = GameObject.Find("XR Rig").transform.position;
            viewCam.SetActive(false);
            mainCam.SetActive(true);
            GameObject.Find("Magnet").GetComponent<MagnetMove>().count++;
            Destroy(other.gameObject);
            GameObject.Find("hall").GetComponent<Dump>().dumpCount = 0;
            GameObject.Find("hall2").GetComponent<Dump>().dumpCount = 0;
            ScoreMat.DOColor(Color.white, 1.5f);//Ui
            GameObject.Find("ScoreBoard1").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("ScoreBoard2").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum1").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum2").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum3").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum4").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum5").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum6").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum7").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum8").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum9").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("Sum10").GetComponent<Text>().DOColor(Color.red, 0.1f);
            GameObject.Find("ScoreBoardTotal").GetComponent<Text>().DOColor(Color.red, 0.1f);
        }
        else Destroy(other.gameObject);
    }
    void tCountUp()
    {
        isStart = true;
        GameObject.Find("Score").GetComponent<Score>().tCount++;
    }
    void isCollideM()
    {
        isCollide = true;
    }
    void isMoveOff()
    {
        GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isMove = false;
    }
}
