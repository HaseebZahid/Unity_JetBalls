using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameReview : MenuBase
{
    public InputField inputFieldText;
    public Text placeholderText;

    private void OnEnable()
    {
        switch(LanguagePreference.instance.langValue)
        {
            case 0:
                placeholderText.text = "Enter text...";
                break;
            case 1:
                placeholderText.text = "Введите текст...";
                break;
            case 2:
                placeholderText.text = "introducir texto...";
                break;
        }
    }

    public override void SwitchState(bool stateEnable)
    {
        gameObject.SetActive(stateEnable);
    }

    public void OnMenuButtonPress()
    {
        MenuManager.instance.SwitchToMenu(MenuState.mainmenu);
    }


    public void OnReviewButtonPress()
    {

    }
}
