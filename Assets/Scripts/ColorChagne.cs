using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChagne : MonoBehaviour
{
    [SerializeField] Light direcLight;
    [SerializeField] Material WallM;
    [SerializeField] Camera mainCam;
    bool colorC = false;
    bool minus = false;
    float a = 0;
    float b = 0;
    void Update()
    {
        mainCam.backgroundColor = new Color(a, b, 1, 0.6f);
        direcLight.color = new Color(a, b, 1);
        WallM.color = new Color(a, b ,1);
        if (!colorC)
        {

            if (a >= 1) minus = true;
            if (minus) a -= Time.deltaTime;
            else a += Time.deltaTime; ;
            if(minus && a <= 0)
            {
                minus = false;
                colorC = true;
            }
        }
        else
        {
            if (b >= 1) minus = true;
            if (minus) b -= Time.deltaTime;
            else b += Time.deltaTime;
            if (minus && b <= 0)
            {
                minus = false;
                colorC = false;
            }
        }
    }
}
