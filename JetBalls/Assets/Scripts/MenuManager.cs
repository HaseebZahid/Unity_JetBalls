using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuStates { mainmenu, gameplay, gamelose, settings, review}

public class MenuManager : MonoBehaviour
{
    [LabeledArrayAttribute(typeof(MenuStates))]
    public MenuBase[] allMenus;

    public static MenuManager instance;
    private void Awake()
    {
        instance = this;
    }

}
