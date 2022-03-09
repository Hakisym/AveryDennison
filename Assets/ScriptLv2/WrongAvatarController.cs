using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongAvatarController : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<IButton>().OnWrongButtonClickedOnce += HandleWrongButtonAudio;
        GetComponent<IButton>().OnWrongButtonClickedTwice += HandleWrongButtonAudio2;
    }

    void HandleWrongButtonAudio()
    {
        AudioMain.instance.EventPlayClip(3, false);
    }

    void HandleWrongButtonAudio2()
    {
        AudioMain.instance.EventPlayClip(4, false);
    }
}