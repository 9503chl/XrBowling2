using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometrics : MonoBehaviour
{
    public static float GetSine(float angle)
    {
        return Mathf.Sin(angle * Mathf.Deg2Rad);
    }
    public static float GetCosine(float angle)
    {
        return Mathf.Cos(angle * Mathf.Deg2Rad);
    }
    public static float GetTangent(float angle)
    {
        return Mathf.Tan(angle * Mathf.Deg2Rad);
    }
    public static List<Vector2> CreateSectorForm(Vector2 direction, int angle, float radius)
    {
        List <Vector2> tempList = new List<Vector2>();

        direction *= radius;

        tempList.Add(Vector2.zero);

        for (int i = -angle / 2; i <= angle / 2; i++)
        {
            tempList.Add(Quaternion.AngleAxis(i, Vector3.forward) * direction);
        }
        tempList.Add(Vector2.zero);

        return tempList;
    }
}
