using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public static void CursurChange(Texture2D texture2D)
    {
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
    }
}
