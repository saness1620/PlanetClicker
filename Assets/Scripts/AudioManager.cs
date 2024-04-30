using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip _buttonClickSFX;
    [SerializeField] private AudioClip _LockOfMoneySFX;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _soundAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;

    public static AudioManager Instance {get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void PlayButtonClickSound()
    {
        _soundAudioSource.PlayOneShot(_buttonClickSFX);
    }

    public void PlayLockOfMoneySound()
    {
        _soundAudioSource.PlayOneShot(_LockOfMoneySFX);
    }

    public void SetSoundVolume(float value)
    {
        _soundAudioSource.volume = value;
    }

    public void SetMusicVolume(float value)
    {
        _musicAudioSource.volume = value;
    }

    public void SwitchAudioEnabling(bool value)
    {
        AudioListener.pause = !value;
    }
}
