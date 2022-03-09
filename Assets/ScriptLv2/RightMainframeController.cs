using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMainframeController : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<IButton>().OnRightButtonClicked += ClickedRightMainFrame;
    }

    void ClickedRightMainFrame()
    {
        InventoryList.instance.RaycastObject.Find("02_UVCamera").gameObject.SetActive(true);
        AudioMain.instance.PlayDelayClip(6, 9);
    }
}
