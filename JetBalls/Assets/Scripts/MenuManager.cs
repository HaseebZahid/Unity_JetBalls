using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuState { mainmenu, gameplay, gamelose, settings, review}

public class MenuManager : MonoBehaviour
{
    [LabeledArrayAttribute(typeof(MenuState))]
    public MenuBase[] allMenus;

    public static MenuManager instance;
    private void Awake()
    {
        instance = this;
    }

    MenuState prevMenuState, currMenuState;

    public void SwitchToPreviousMenu()
    {

    }

    public void SwitchToMenu(MenuState newMenu)
    {

    }
}
