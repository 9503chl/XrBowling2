﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MessageBox : View
{
    public Text TitleText;
    public Text MessageText;
    public Button OkButton;
    public Button CancelButton;

    [SerializeField]
    [Range(0f, 60f)]
    public float autoCloseTime = 0f;

    public event UnityAction<bool> OnClose;

    [NonSerialized]
    private int ID = 0;

    [NonSerialized]
    private bool result = false;

    [NonSerialized]
    private Coroutine standbyRoutine;

    private static List<View> popups = new List<View>();

    private static MessageBox template = null;

    private static int uniqueID = 0;

    private void Awake()
    {
        OnBeforeShow += MessageBox_OnBeforeShow;
        OnAfterShow += MessageBox_OnAfterShow;
        OnBeforeHide += MessageBox_OnBeforeHide;
        OnAfterHide += MessageBox_OnAfterHide;

        if (template == null)
        {
            template = this;
        }
    }

    private void OnEnable()
    {
        if (template == this)
        {
            gameObject.SetActive(false);
        }
        else
        {
            popups.Add(this);
        }
    }

    private void OnDisable()
    {
        if (template != this)
        {
            popups.Remove(this);
        }
    }

    private void MessageBox_OnBeforeShow()
    {
    }

    private void MessageBox_OnAfterShow()
    {
        if (autoCloseTime > 0f)
        {
            standbyRoutine = StartCoroutine(Standby());
        }
    }

    private void MessageBox_OnBeforeHide()
    {
        if (standbyRoutine != null)
        {
            StopCoroutine(standbyRoutine);
        }
    }

    private void MessageBox_OnAfterHide()
    {
        if (OnClose != null)
        {
            OnClose.Invoke(result);
        }
        Destroy(gameObject);
    }

    private IEnumerator Standby()
    {
        yield return new WaitForSeconds(autoCloseTime);
        Close(false);
    }

    private void Prepare(string message, string buttonOk, string buttonCancel, string title)
    {
        if (TitleText != null)
        {
            TitleText.text = title;
            if (string.IsNullOrEmpty(title))
            {
                TitleText.gameObject.SetActive(false);
            }
        }
        if (MessageText != null)
        {
            MessageText.text = message;
        }
        if (OkButton != null)
        {
            OkButton.GetComponentInChildren<Text>().text = buttonOk;
            OkButton.onClick.AddListener(OkButtonClick);
        }
        if (CancelButton != null)
        {
            CancelButton.GetComponentInChildren<Text>().text = buttonCancel;
            CancelButton.onClick.AddListener(CancelButtonClick);
        }
        if (string.IsNullOrEmpty(buttonCancel))
        {
            if (OkButton != null && CancelButton != null)
            {
                float centerX = (OkButton.transform.localPosition.x + CancelButton.transform.localPosition.x) / 2;
                OkButton.transform.localPosition = new Vector3(centerX, OkButton.transform.localPosition.y, OkButton.transform.localPosition.z);
                CancelButton.gameObject.SetActive(false);
            }
        }
    }

    private void Close(bool isOk)
    {
        result = isOk;
        Hide();
    }

    private void OkButtonClick()
    {
        Close(true);
    }

    private void CancelButtonClick()
    {
        Close(false);
    }

    public static int Show(string message, string buttonOk, float autoCloseTime = 0f, UnityAction<bool> onClose = null)
    {
        return Show(message, buttonOk, null, null, autoCloseTime, onClose);
    }

    public static int Show(string message, string buttonOk, string buttonCancel, float autoCloseTime = 0f, UnityAction<bool> onClose = null)
    {
        return Show(message, buttonOk, buttonCancel, null, autoCloseTime, onClose);
    }

    public static int Show(string message, string buttonOk, string buttonCancel, string title, float autoCloseTime = 0f, UnityAction<bool> onClose = null)
    {
        if (template == null)
        {
            MessageBox[] popups = Resources.FindObjectsOfTypeAll<MessageBox>();
            if (popups.Length > 0)
            {
                template = popups[0];
            }
        }
        if (template != null)
        {
            MessageBox popup = Instantiate(template, template.transform.parent);
            popup.Prepare(message, buttonOk, buttonCancel, title);
            popup.ID = uniqueID++;
            popup.autoCloseTime = autoCloseTime;
            popup.OnClose = onClose;
            popup.Show();
            return popup.ID;
        }
        return -1;
    }

    public static void Close(int ID)
    {
        foreach (MessageBox popup in popups)
        {
            if (popup.ID == ID)
            {
                popup.Close(false);
                break;
            }
        }
    }

    public static void CloseAll()
    {
        foreach (MessageBox popup in popups)
        {
            popup.Close(false);
        }
    }
}
