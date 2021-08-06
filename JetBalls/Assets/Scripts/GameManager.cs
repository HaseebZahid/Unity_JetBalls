using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundState soundState;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;

        soundState = new SoundState();
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