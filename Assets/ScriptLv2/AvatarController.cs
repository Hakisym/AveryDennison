using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using RootMotion.FinalIK;

public class AvatarController : MonoBehaviour
{
    private VRIK[] Avatars;

    private void Awake()
    {
        Avatars = GetComponentsInChildren<VRIK>(true);
        FindObjectOfType<GameManagerLv2>().OnAvatarChange += ChangeAvatar;
    }

    void ChangeAvatar(int i)
    {
        foreach (var item in Avatars)
        {
            item.gameObject.SetActive(false);
        }
        Avatars[i].gameObject.SetActive(true);
    }
}
