using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLose : MenuBase
{
    public Text bestScoreText, currScoreText;

    private void OnEnable()
    {
        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        int currScore = Mathf.FloorToInt(GameManager.instance.currScore);
        if (bestScore < currScore)
        {
            bestScore = currScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }

        bestScoreText.text = bestScore.ToString();
        currScoreText.text = currScore.ToString();

    }

    public override void SwitchState(bool stateEnable)
    {
        gameObject.SetActive(stateEnable);
    }

    public void OnPressMainMenu()
    {
        MenuManager.instance.SwitchToMenu(MenuState.mainmenu);
    }

    public void OnPressRestart()
    {
        GameManager.instance.StartGame();
        MenuManager.instance.SwitchToMenu(MenuState.gameplay);
    }
}
