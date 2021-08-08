using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundState soundState;

    public ObjectSpawner[] objSpawners;
    public BallMovement[] players;

    public static GameManager instance;

    public bool isPlaying = false;

    private void Awake()
    {
        instance = this;

        soundState = new SoundState();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        isPlaying = true;

        foreach (ObjectSpawner objSpawner in objSpawners)
        {
            objSpawner.Reset();
        }

        foreach (BallMovement ballMovement in players)
        {
            ballMovement.Reset();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        //Time.timeScale = 0f;
        isPlaying = false;


        foreach (ObjectSpawner objSpawner in objSpawners)
        {
            objSpawner.StopMovement();
        }

        foreach (BallMovement ballMovement in players)
        {
            ballMovement.StopMovement();
        }

        MenuManager.instance.SwitchToMenu(MenuState.gamelose);
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