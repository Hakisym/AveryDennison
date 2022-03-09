using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongMainframeController : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<IButton>().OnWrongButtonClickedOnce += HandleWrongButtonAudio;
        GetComponent<IButton>().OnWrongButtonClickedTwice += HandleWrongButtonAudio2;
    }

    void HandleWrongButtonAudio()
    {
        AudioMain.instance.EventPlayClip(7, false);
    }

    void HandleWrongButtonAudio2()
    {
        AudioMain.instance.EventPlayClip(8, false);
    }
}
