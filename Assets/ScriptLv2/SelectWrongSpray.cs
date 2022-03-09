using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWrongSpray : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SelectorUIController>().OnWrongButtonSelectOnce += HandleRightSpray;
    }

    void HandleRightSpray()
    {
        AudioMain.instance.EventPlayClip(24, false);
    }
}
