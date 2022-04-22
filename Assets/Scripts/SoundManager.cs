using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    [SerializeField] private AudioSource _audioSource;

    private AudioClip _coin;
    private AudioClip _hurt;
    private AudioClip _rewind;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _coin = Resources.Load<AudioClip>("Sounds/coin");
        _hurt = Resources.Load<AudioClip>("Sounds/hurt");
        _rewind = Resources.Load<AudioClip>("Sounds/rewind");
    }

    public void PlayCoinEffect()
    {
        _audioSource.PlayOneShot(_coin);
    }
    public void PlayHurtEffect()
    {
        _audioSource.PlayOneShot(_hurt);
    }
    public void PlayRewindEffect()
    {
        _audioSource.PlayOneShot(_rewind);
    }
    
    
}
