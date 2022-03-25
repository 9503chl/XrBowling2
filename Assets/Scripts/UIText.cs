using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class UIText : MonoBehaviour
{
    Text uiText;
    private void Start()
    {
        uiText = GetComponent<Text>();
    }
    void Update()
    {
        if(GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isLeft)
        {
            uiText.DOFade(100, 0.1f); 
            uiText.text = string.Format("왼쪽 회전 {0:f2}",Mathf.Abs(GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().power));
            uiText.DOFade(0, 2);
        }
        if(GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isRight)
        {
            uiText.DOFade(100, 0.1f);
            uiText.text = string.Format("오른쪽 회전 {0:f2}", GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().power);
            uiText.DOFade(0, 2f);
        }
        if(GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isNormal)
        {
            uiText.DOFade(100, 0.1f);
            uiText.text = string.Format("무회전");
            uiText.DOFade(0, 2f);
        }
    }
}
