using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioConnecter : Singleton<AudioConnecter>
{
    [SerializeField] protected AudioManager audioSource;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        PlayerHealth.Instance.audioManager = audioSource;
    }
}
