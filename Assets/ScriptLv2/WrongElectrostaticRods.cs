using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongElectrostaticRods : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<IButton>().OnWrongButtonClickedOnce += HandleWrongElectrostaticRodsAudio;
        GetComponent<IButton>().OnWrongButtonClickedTwice += HandleWrongElectrostaticRodsAudio2;
    }

    void HandleWrongElectrostaticRodsAudio()
    {
        AudioMain.instance.EventPlayClip(20, false);
    }

    void HandleWrongElectrostaticRodsAudio2()
    {
        AudioMain.instance.EventPlayClip(21, false);
    }
}
