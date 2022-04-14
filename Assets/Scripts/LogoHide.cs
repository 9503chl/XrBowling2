using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LogoHide : MonoBehaviour
{
    void Update()
    {
        if (GameObject.Find("Spawner").GetComponent<Ball>().isGone)
        {
            if (gameObject.transform.tag == "LogoText")
            {
                gameObject.GetComponent<Text>().DOFade(0, 0.01f);
            }
            else gameObject.GetComponent<SpriteRenderer>().DOFade(0, 0.01f);
        }
        if (GameObject.FindWithTag("Score").GetComponent<ScoreText>().count == 4)
        {
            if (gameObject.transform.tag == "LogoText")
            {
                gameObject.GetComponent<Text>().DOColor(Color.black, 4.51f);
            }
            else gameObject.GetComponent<SpriteRenderer>().DOColor(Color.white, 4.51f);
        }
    }
}
