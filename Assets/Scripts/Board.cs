using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;
using System;

public class Board : MonoBehaviour
{
    [SerializeField] private List<Text> FirstRoundText;
    [SerializeField] private List<Text> SecondRoundText;
    [SerializeField] private List<Text> ThirdRoundText;
    [SerializeField] private List<Text> FourthRoundText;
    [SerializeField] private List<Text> FifthRoundText;
    [SerializeField] private List<Text> SixthRoundText;
    [SerializeField] private List<Text> SeventhRoundText;
    [SerializeField] private List<Text> EighthRoundText;
    [SerializeField] private List<Text> NinethRoundText;
    [SerializeField] private List<Text> TenthRoundText;

    [SerializeField] private List<Text> SumTexts;

    [SerializeField] private Text TotalText;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void TextInit(Dictionary<int,PointSystem> PointsDic, int totalSum)
    {
        foreach(KeyValuePair<int ,PointSystem> pair in PointsDic)
        {
            List<Text> textList = null;

            switch (pair.Key)
            {
                case 0: textList = FirstRoundText; break;
                case 1: textList = SecondRoundText; break;
                case 2: textList = ThirdRoundText; break;
                case 3: textList = FourthRoundText; break;
                case 4: textList = FifthRoundText; break;
                case 5: textList = SixthRoundText; break;
                case 6: textList = SeventhRoundText; break;
                case 7: textList = EighthRoundText; break;
                case 8: textList = NinethRoundText; break;
                case 9: textList = TenthRoundText; break;
            }

            for (int i = 0;i< pair.Value.Points.Count; i++)
            {
                textList[i].text = pair.Value.Points[i].ToString(); ;
            }

            SumTexts[pair.Key].text = pair.Value.RoundPoint.ToString();
        }

        TotalText.text = totalSum.ToString();

        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        canvasGroup.DOFade(1, 0.5f);

        yield return new WaitForSeconds(3);

        canvasGroup.DOFade(0, 0.5f);
    }
}
