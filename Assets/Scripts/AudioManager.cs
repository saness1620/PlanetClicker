using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonClickSFX;
    [SerializeField] private AudioClip _LockOfMoneySFX;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private Slider _sfxSlider;

    private AudioSource _audioSource;

    public static AudioManager Instance {get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void PlayButtonClickSound()
    {
        _audioSource.PlayOneShot(_buttonClickSFX);
    }

    public void PlayLockOfMoneySound()
    {
        _audioSource.PlayOneShot(_LockOfMoneySFX);
    }

    public void SetVolumeSfx(float value)
    {
        _sfxSource.volume = value;
    }
}
