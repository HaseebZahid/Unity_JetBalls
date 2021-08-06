using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuBase
{
    public enum MainMenuButton { play, settings, info, review}

    public GameObject mainMenuOverlay;

    public override void SwitchState(bool stateEnable)
    {
        mainMenuOverlay.SetActive(stateEnable);
        gameObject.SetActive(stateEnable);
    }

    public void HandleOnClick (int mainMenuButton)
    {
        switch((MainMenuButton) mainMenuButton)
        {
            case MainMenuButton.play:       //0
                break;
            case MainMenuButton.settings:   //1
                break;
            case MainMenuButton.info:       //2
                break;
            case MainMenuButton.review:     //3
                break;
        }
    }

}
