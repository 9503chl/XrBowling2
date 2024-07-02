using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;

        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();

        nonAnnounceList.AddRange(audioSources);

        for(int i = 0; i<AnnounceSounds.Length; i++)
        {
            nonAnnounceList.Remove(AnnounceSounds[i]);
        }
    }

    private List <AudioSource> nonAnnounceList = new List <AudioSource>();

    [SerializeField] private AudioSource[] AnnounceSounds;


    public void AnnouncePlay(float time)
    {
        for(int i = 0; i< nonAnnounceList.Count; i++)
        {
            nonAnnounceList[i].volume = 0.1f;
            nonAnnounceList[i].DOFade(0.7f, time + 1).SetEase(Ease.InExpo);
        }
    }
}
