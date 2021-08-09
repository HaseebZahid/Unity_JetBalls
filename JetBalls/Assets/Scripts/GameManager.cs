using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUD hud;

    public ObjectSpawner[] objSpawners;
    public BallMovement[] players;

    public static GameManager instance;

    public bool isPlaying = false;

    private void Awake()
    {
        instance = this;

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

        AudioManager.instance.SetMusicState(true);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        //Time.timeScale = 0f;
        isPlaying = false;
        AudioManager.instance.SetMusicState(false);

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

