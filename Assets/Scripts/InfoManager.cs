using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public static InfoManager Instance;

    [SerializeField] private GameObject InfoGroup;

    public bool isOn = false;


    private void Awake()
    {
        Instance = this;
    }
    public void InfoPanelOnOff()
    {
        InfoGroup.SetActive(!isOn);
        isOn ^= true;
    }
}
