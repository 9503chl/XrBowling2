using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimationGroup : MonoBehaviour
{
    [SerializeField] private GameObject[] Alphabets;

    [SerializeField] private GameObject titleImage;

    [SerializeField] private GameObject pointerObj;

    private List <Vector3> basePosition_Alphabet = new List<Vector3> ();

    private Vector3 titlePosition;

    private Coroutine coroutine;

    private void Awake()
    {
        for (int i = 0; i < Alphabets.Length; i++)
        {
            basePosition_Alphabet.Add(Alphabets[i].transform.position);
        }
        titlePosition = titleImage.transform.position;
    }

    private void OnEnable()
    {
        AnimationInvoke();
    }
    private void AnimationInvoke()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        coroutine = StartCoroutine(AnimationCor());
    }
    IEnumerator AnimationCor()
    {
        for (int i = 0; i < Alphabets.Length; i++)
        {
            Alphabets[i].SetActive(true);
            Alphabets[i].transform.position = basePosition_Alphabet[i];
        }

        titleImage.transform.position = titlePosition;

        pointerObj.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < Alphabets.Length; i++)
        {
            Alphabets[i].transform.DOMoveZ(10, 0.5f);

            yield return new WaitForSeconds(0.5f);

            Alphabets[i].SetActive(false);
        }

        titleImage.transform.DOMoveZ(5, 0.8f).SetEase(Ease.InExpo);

        yield return new WaitForSeconds(0.8f);

        pointerObj.SetActive(true);
    }
}
