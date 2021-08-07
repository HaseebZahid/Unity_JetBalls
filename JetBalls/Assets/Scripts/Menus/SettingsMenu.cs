using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MenuBase
{
    public Image soundIcon;

    public Sprite soundOn, soundOff;

    public Image engIcon, rusIcon, spanIcon;

    public Sprite engOn, engOff, rusOn, rusOff, spanOn, spanOff;

    public override void SwitchState(bool stateEnable)
    {
        gameObject.SetActive(stateEnable);
    }

    private void OnEnable()
    {
        Invoke("UpdateIcons", 0.5f);
    }

    public void OnBackButton()
    {
        MenuManager.instance.SwitchToPreviousMenu();
    }

    public void ToggleSound()
    {
        bool currentSoundState = GameManager.instance.soundState.isPlaying;
        GameManager.instance.soundState.isPlaying = !currentSoundState;
        UpdateIcons();
    }

    public void SetLanguagePreference(int newValue)
    {
        LanguagePreference.instance.langValue = newValue;
        UpdateIcons();
    }

    void UpdateIcons()
    {
        int langValue = LanguagePreference.instance.langValue;
        engIcon.sprite = langValue == 0 ? engOn : engOff;
        rusIcon.sprite = langValue == 1 ? rusOn : rusOff;
        spanIcon.sprite = langValue == 2 ? spanOn : spanOff;

        soundIcon.sprite = GameManager.instance.soundState.isPlaying ? soundOn : soundOff;
    }
}
