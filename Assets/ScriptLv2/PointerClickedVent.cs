using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClickedVent : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<RaycastPointer>().OnRaycastClicked += HandleClickedVent;
    }

    void HandleClickedVent(PointerEventData pointerEvent)
    {
        gameObject.SetActive(false);
        InventoryList.instance.HighlightObjects.Find("00_Tank").gameObject.SetActive(true);
        GameObject.Find("GrabbableClip").SetActive(true);
        AudioMain.instance.EventPlayClip(13, false);
    }
}
