using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void TextInit(List<List<int>> RoundScores)
    {
        for(int i = 0; i<RoundScores.Count; i++)
        {
            
            for(int j = 0; j< RoundScores[i].Count; j++)
            {

            }
        }
        //법칙을 알아야함.
    }
}
