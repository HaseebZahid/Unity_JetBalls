using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLose : MenuBase
{


    public override void SwitchState(bool stateEnable)
    {
        throw new System.NotImplementedException();
    }

    public void OnPressMainMenu()
    {
        MenuManager.instance.SwitchToMenu(MenuState.mainmenu);
    }
    public void OnPressRestart()
    {
        MenuManager.instance.SwitchToMenu(MenuState.gameplay);
    }
}
