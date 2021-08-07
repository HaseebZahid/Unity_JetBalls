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
        SwitchToMenu(prevMenuState);
    }

    public void SwitchToMenu(MenuState newMenuState)
    {
        prevMenuState = currMenuState;
        currMenuState = newMenuState;
        
        //if ((prevMenuState == MenuState.mainmenu && currMenuState == MenuState.gameplay))
            allMenus[(int)prevMenuState].SwitchState(false);

        allMenus[(int)currMenuState].SwitchState(true);

    }
}
