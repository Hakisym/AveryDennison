using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongElectrostaticRodsFirst : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<IButton>().OnWrongButtonClickedTwice += ClickedWrongElectrostaticRods;
    }

    void ClickedWrongElectrostaticRods()
    {
        AudioMain.instance.EventPlayClip(17, false);
    }
}
