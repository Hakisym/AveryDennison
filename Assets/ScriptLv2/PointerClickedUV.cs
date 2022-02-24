using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using HighlightPlus;

public class PointerClickedUV : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<RaycastPointer>().OnRaycastClicked += HandleClickedUV;
    }

    void HandleClickedUV(PointerEventData pointerEvent)
    {
        gameObject.SetActive(false);
        InventoryList.instance.Selector.Find("02_UVCamera").gameObject.SetActive(true);
    }

}
