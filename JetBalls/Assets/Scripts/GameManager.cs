﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUD hud;

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

    public float currScore = 0f;

    public void StartGame()
    {
        Time.timeScale = 1f;
        isPlaying = true;
        hud.UpdateScore(0);
        currScore = 0f;

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

    private void Update()
    {
        if (!isPlaying)
            return;

        if (Input.touchCount > 0)
        {
            HandleTouchInput();
        }
        else
        {
            HandleMouseInput();
        }

        UpdateScore();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInputInPixelCoordinated(Input.mousePosition);
        }
    }   
    
    void HandleTouchInput()
    {
        foreach(Touch touch in Input.touches)
        {
            HandleInputInPixelCoordinated(touch.position);
        }
    }

    void HandleInputInPixelCoordinated(Vector2 pixelPos)
    {
        Debug.Log(pixelPos.ToString());

        if (pixelPos.y < (0.3f * Screen.height))
        {
            // bottom
            players[0].HandleInput();
        }
        else if (pixelPos.y < (0.6f * Screen.height))
        {
            // middle
            players[1].HandleInput();
        }
        else
        {
            // top
            players[2].HandleInput();
        }
    }


    void UpdateScore()
    {
        currScore += Time.deltaTime;
        hud.UpdateScore(Mathf.FloorToInt(currScore));
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