using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource mainMusicSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Background Sound")]
    public AudioClip mainBackground;
    public AudioClip additionalBackground;

    [Header("SFX Sound")]
    public AudioClip death;
    public AudioClip gameover;
    public AudioClip healing;
    public AudioClip heartbeat;

    private void Start()
    {
        mainMusicSource.clip = mainBackground;
        musicSource.clip = additionalBackground;

        mainMusicSource.Play();
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}