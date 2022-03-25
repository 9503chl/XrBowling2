using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject panelUI;
    [SerializeField] GameObject shoes;
    [SerializeField] GameObject ball;
    public string[,] PointNow = new string[10, 3];
    public int round = 0; //10����
    public int tCount = 0; //1,2��
    public int sCount = 0; //������
    public int totalScore = 0;
    int beforeScore = 0;
    bool isSpare = false;
    public bool turnEnd = false;
    void FixedUpdate()
    {
        if (round == 10)
        {
            panelUI.SetActive(true);
            ball.SetActive(false);
            shoes.SetActive(false);
        }
        if(GameObject.Find("BreakWall").GetComponent<DesPin>().isStart)
        {
            if (tCount == 1 && sCount == 10) // ��Ʈ����ũ
            {
                if (isSpare)
                {
                    int a = int.Parse(PointNow[round - 1, 2]);
                    PointNow[round - 1, 2] += a+10;
                    isSpare = false;
                    totalScore += 10;
                }
                PointNow[round, 0] = "X";
                if (round == 0)
                {
                    PointNow[round, 2] += 30;
                }
                else
                {
                    int a = int.Parse(PointNow[round, 2]);
                    PointNow[round, 2] += a + 30;
                }
                totalScore += int.Parse(PointNow[round, 2]);
                round++; tCount = 0; turnEnd = true; sCount = 0;
                GameObject.Find("Magnet").GetComponent<MagnetMove>().count = 3; //�ٷ� �ʱ�ȭ
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }

            if (beforeScore + sCount == 10) // �����
            {
                if (round == 0) PointNow[round, 2] += beforeScore + sCount;
                else PointNow[round, 2] += int.Parse(PointNow[round - 1, 2]) + beforeScore + sCount;
                PointNow[round, 1] = "/";
                totalScore += int.Parse(PointNow[round, 2]);
                isSpare = true; round++; tCount = 0; turnEnd = true; sCount = 0;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }

            if (sCount == 0 && !turnEnd) //0�� 
            {
                PointNow[round, tCount-1] = "-"; turnEnd = true;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }

            else if(tCount == 1)
            {
                if (isSpare)
                {
                    PointNow[round - 1, 2] += sCount;
                    isSpare = false;
                }
                PointNow[round, 0] += sCount;
                beforeScore = sCount; sCount = 0; turnEnd = true;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }

            if (tCount == 2) //2�� �پ�
            {
                if (round == 0) PointNow[round, 2] += beforeScore + sCount;
                else PointNow[round, 2] += int.Parse(PointNow[round - 1, 2]) + beforeScore + sCount;
                if(sCount != 0) PointNow[round, 1] += sCount;
                totalScore += int.Parse(PointNow[round, 2]);
                round++; tCount = 0; turnEnd = true; beforeScore = 0; sCount = 0;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }

        }
    }
}
