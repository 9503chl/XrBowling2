using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DoFade1 : MonoBehaviour
{

    void Update()
    {
        if (GameObject.FindWithTag("Score").GetComponent<ScoreText>().count == 4)
        {
            if (gameObject.tag == "Score" || gameObject.tag == "ScoreBoard")
            {
                gameObject.GetComponent<Text>().DOFade(0, 4.5f);
            }
            else gameObject.GetComponent<SpriteRenderer>().DOFade(0, 4.5f);
        }
    }
}
