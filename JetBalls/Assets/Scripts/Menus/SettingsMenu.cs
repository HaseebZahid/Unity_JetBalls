using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MenuBase
{
    public Image soundIcon;

    public Sprite soundOn, soundOff;

    public override void SwitchState(bool stateEnable)
    {
        gameObject.SetActive(stateEnable);
    }

    public void OnBackButton()
    {

    }

    public void ToggleSound()
    {

    }
}
