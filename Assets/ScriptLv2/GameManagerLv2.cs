using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManagerLv2 : MonoBehaviour
{
    public Action<int> OnAvatarChange;
    
    void Start()
    {
        OnAvatarChange(0);
    }

}
