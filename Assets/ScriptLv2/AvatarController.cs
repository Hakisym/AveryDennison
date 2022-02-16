using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AvatarController : MonoBehaviour
{
    public GameObject[] Avatars;
    private GameManagerLv2 gameManagerLv2;
    private void Awake()
    {
        gameManagerLv2 = FindObjectOfType<GameManagerLv2>();
        gameManagerLv2.OnAvatarChange += ChangeAvatar;
    }

    void ChangeAvatar(int i)
    {
        foreach (var item in Avatars)
        {
            item.SetActive(false);
        }
        Avatars[i].SetActive(true);
    }
}
