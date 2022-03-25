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
            uiText.text = string.Format("���� ȸ�� {0:f2}",Mathf.Abs(GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().power));
            uiText.DOFade(0, 2);
        }
        if(GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isRight)
        {
            uiText.DOFade(100, 0.1f);
            uiText.text = string.Format("������ ȸ�� {0:f2}", GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().power);
            uiText.DOFade(0, 2f);
        }
        if(GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isNormal)
        {
            uiText.DOFade(100, 0.1f);
            uiText.text = string.Format("��ȸ��");
            uiText.DOFade(0, 2f);
        }
    }
}
