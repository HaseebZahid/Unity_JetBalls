using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLose : MenuBase
{


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
