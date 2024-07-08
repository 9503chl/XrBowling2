using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    public void TextInit(List<List<int>> RoundScores)
    {
        int TotalSum = 0;

        for(int i = 0; i<RoundScores.Count; i++)
        {
            int Sum = 0;
            for(int j = 0; j< RoundScores[i].Count; j++)
            {
                FirstRoundText[j].text = RoundScores[i][j].ToString();
                Sum += RoundScores[i][j];
            }
            SumTexts[i].text = Sum.ToString();

            TotalSum += Sum;
        }

        TotalText.text = TotalSum.ToString();

        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        canvasGroup.DOFade(1, 0.5f);

        yield return new WaitForSeconds(3);

        canvasGroup.DOFade(1, 0.5f);
    }
}
