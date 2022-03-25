using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


[RequireComponent(typeof(TextMesh))]

public class ScoreText : MonoBehaviour
{
    [SerializeField] AudioSource textSound;
    Text uiText;
    public int count = 0;
    void Start()
    {
        uiText = GetComponent<Text>();
    }
    void Update()
    {
        if(count == 4)
        {
            GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            count = 0;
        }
        if (GameObject.Find("Score").GetComponent<Score>().turnEnd) 
        {
            textSound.Play();
            if (gameObject.name == "ScoreBoard1")
            {
                string str = "";
                for(int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 0];
                }
                uiText.DOText(str, 0.5f);
                count++;
            }
            else if (gameObject.name == "ScoreBoard2")
            {
                string str = "";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 1];
                }
                uiText.DOText(str, 0.5f);
                count++;
            }
            else if (gameObject.tag == "ScoreBoard") 
            {
                for (int i = 0; i < 10; i++)
                {
                    GameObject.Find("Sum"+(i+1)).GetComponent<Text>().DOText(GameObject.Find("Score").GetComponent<Score>().PointNow[i, 2], 0.5f);
                }
                count++;
            }
            else if (gameObject.name == "ScoreBoardTotal")
            {
                string str = "";
                str += GameObject.Find("Score").GetComponent<Score>().totalScore;
                uiText.DOText(str, 0.5f);
                count++;
            }
        }
    }
}