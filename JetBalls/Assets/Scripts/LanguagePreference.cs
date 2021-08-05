using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguagePreference : MonoBehaviour
{
    public const string prefKey = "LanguagePreferenceKey";

    public static LanguagePreference instance;
    private void Awake()
    {
        instance = this;

        langValue = PlayerPrefs.GetInt(prefKey, 0);
    }

    int m_value;

    public int langValue
    {
        get
        {
            return m_value;
        }

        set
        {
            m_value = value;
            PlayerPrefs.SetInt(prefKey, m_value);
        }
    }
}
