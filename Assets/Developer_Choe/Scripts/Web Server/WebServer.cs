using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebServer : MonoBehaviour
{
    public void ApiGet()
    {
        StartCoroutine(ApiGetInfo());
    }
    IEnumerator ApiGetInfo()
    {
        UnityWebRequest www = UnityWebRequest.Get(string.Empty);
        www.useHttpContinue = false;
        www.downloadHandler = new DownloadHandlerBuffer();
        www.disposeDownloadHandlerOnDispose = true;

        www.timeout = 30;

        yield return www.SendWebRequest();

        if (www.error != null)
        {
            Debug.LogError(www.error);
        }
        else
        {
            string json = string.Empty;
            www.Dispose();

        }
    }
    public void ApiPost()//테스트 필요.
    {
        StartCoroutine(ApiPostInfo());
    }
    IEnumerator ApiPostInfo()
    {
        UnityWebRequest www = UnityWebRequest.Post(string.Empty, string.Empty);
        www.useHttpContinue = false;
        www.downloadHandler = new DownloadHandlerBuffer();
        www.disposeDownloadHandlerOnDispose = true;

        www.timeout = 30;

        yield return www.SendWebRequest();

        if (www.error != null)
        {
            Debug.LogError(www.error);
        }
        else
        {
            string json = string.Empty;
            www.Dispose();

        }
    }


    public void GetTextureByURL()
    {
        StartCoroutine(GetTexture());
    }
    IEnumerator GetTexture()
    {
        string downloadURL = string.Empty;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(downloadURL);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {

        }
    }
}
