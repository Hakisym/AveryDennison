using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManagerLv2 : MonoBehaviour
{
    public Action<int> OnAvatarChange = delegate { };
    
    void Start()
    {
        OnAvatarChange(0);
        InventoryList.instance.UICanvas.Find("00_Avatar").gameObject.SetActive(true);
        AudioMain.instance.EventPlayClip(1, false);
    }

}
