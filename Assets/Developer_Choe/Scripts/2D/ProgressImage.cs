using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressImage : MonoBehaviour
{
    private Image _Image;

    private float fillValue;

    public float FillValue
    {
        get { return fillValue; }
        set { FillAmountChange(value); }
    }

    private void Awake()
    {
        _Image = GetComponent<Image>();
        _Image.type = Image.Type.Filled;
    }
    public void FillAmountChange(float value)
    {
        if(_Image != null)
        {
            return;
        }
        _Image.fillAmount = value;
    }
}
