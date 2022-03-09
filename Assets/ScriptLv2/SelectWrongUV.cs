using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWrongUV : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SelectorUIController>().OnWrongButtonSelectOnce += HandleWrongUV;
    }

    void HandleWrongUV()
    {
        AudioMain.instance.EventPlayClip(11, false);
    }
}
