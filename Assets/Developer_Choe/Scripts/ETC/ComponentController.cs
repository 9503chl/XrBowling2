using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    public static ComponentController Instance;

    private MonoBehaviour[] monoBehaviours;

    private List<MonoBehaviour> CanDiableMonos = new List<MonoBehaviour>();

    private void Awake()
    {
        Instance = this;

        monoBehaviours = GetComponentsInChildren<MonoBehaviour>();
        for(int i = 0; i < monoBehaviours.Length; i++)
        {
        }
        DisableComponents();
    }
    public void DisableComponents()
    {
        for(int i = 0; i < CanDiableMonos.Count; i++)
        {
        }
    }
    public void EnableComponents()
    {
        for (int i = 0; i < CanDiableMonos.Count; i++)
        {
        }
    }
}
    