using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsHelper : MonoBehaviour
{
    public void SetLanguage()
    {
        if (PlayerPrefs.GetInt("UseEnglish") == 0)
        {
            PlayerPrefs.SetInt("UseEnglish", 1);
        }
        else
        {
            PlayerPrefs.SetInt("UseEnglish", 0);
        }
        Debug.Log(PlayerPrefs.GetInt("UseEnglish"));
    }

    private void Awake()
    {
        if(PlayerPrefs.GetInt("UseEnglish") == 1)
        {
            GetComponent<Toggle>().isOn = true;
            PlayerPrefs.SetInt("UseEnglish", 1);
        }
    }
}
