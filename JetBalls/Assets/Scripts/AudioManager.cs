using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource effectsAudioSource;

    public AudioClip jumpSound, hitSound;

    public SoundState soundState;

    public static AudioManager instance;

    void Awake()
    {
        instance = this;

        soundState = new SoundState();
    }

    public void UpdateSound()
    {
        musicAudioSource.mute = !soundState.isPlaying;
        effectsAudioSource.mute = !soundState.isPlaying;
    }

    public void SetMusicState(bool playMode)
    {
        if (playMode)
        {
            musicAudioSource.Play();
        } else
        {
            musicAudioSource.Stop();
        }
    }
    
    public void PlayJump()
    {
        effectsAudioSource.PlayOneShot(jumpSound);
    }

    public void PlayHit()
    {
        effectsAudioSource.PlayOneShot(hitSound);
    }
}


public class SoundState
{
    const string soundStr = "soundState";

    int m_isPlaying = 1;

    public bool isPlaying
    {
        get
        {
            return m_isPlaying == 1;
        }
        set
        {
            m_isPlaying = value ? 1 : 0;
            PlayerPrefs.SetInt(soundStr, m_isPlaying);
        }
    }

    public SoundState()
    {
        m_isPlaying = PlayerPrefs.GetInt(soundStr, 1);
    }
}