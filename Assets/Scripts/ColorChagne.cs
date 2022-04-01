using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChagne : MonoBehaviour
{
    [SerializeField] Material WallM;
    bool act1 = true;
    bool act2 = false;
    int r, g;
    int a = 0, b = 180;

    void Update()
    {
        WallM.color = new Color(r, g, 255,1);
        if (act1)
        {
            r = a; g = b;
            a++;
            if (a == 180)
            {
                act1 = false;
                act2 = true;
            }
        }
        if (act2)
        {
            r = b; g = a;
            b--;
            if (b == 180)
            {
                act1 = true;
                act2 = false;
            }
        }
    }
}
