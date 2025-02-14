using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagaer : MonoBehaviour
{
    public enum BGM
    {
        MainTheme,
        Prologue,
        PlayTheme,
        Puzzle,
        EngindTheme,
        FaillingLoad
    }

    public static SoundManagaer instance = null;

    private AudioSource audioSource;

    public AudioClip[] bgmClips;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayBGM(BGM bgm)
    {
        audioSource.clip = bgmClips[(int)bgm];
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
