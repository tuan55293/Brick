using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [Header("Main Settings:")]
    [Range(0f, 1f)]
    public float musicVolume;
    [Range(0, 1)]
    public float sfxVoloume;

    public AudioSource musicAus;
    public AudioSource sfxAus;

    [Header("Game Sound And Music:")]
    public AudioClip shooting;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip[] bgMusic;

    public override void Awake()
    {
        MakeSingleton(false);
    }
    public override void Start()
    {
        PlayMusic(bgMusic);
    }
    public void PlaySound(AudioClip clip, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }
        if (aus)
        {
            aus.PlayOneShot(clip, sfxVoloume);
        }
    }
    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (musicAus)
        {
            musicAus.clip = clip;
            musicAus.loop = loop;
            musicAus.volume = musicVolume;
            musicAus.Play();
        }
    }
    public void PlayMusic(AudioClip[] clip, bool loop = true)
    {
        if (musicAus)
        {
            int rand = Random.Range(0, clip.Length - 1);
            if (clip[rand])
            {
                musicAus.clip = clip[rand];
                musicAus.loop = loop;
                musicAus.volume = musicVolume;
                musicAus.Play();
            }

        }
    }
}
