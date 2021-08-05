using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public enum MainMenuButton { play, settings, info, review}
    
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
