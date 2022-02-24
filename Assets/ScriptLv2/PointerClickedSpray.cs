using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClickedSpray : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<RaycastPointer>().OnRaycastClicked += HandleClickedSpray;
    }

    void HandleClickedSpray(PointerEventData pointerEvent)
    {
        gameObject.SetActive(false);
        InventoryList.instance.Selector.Find("05_WaterSprayHumidifier").gameObject.SetActive(true);
    }
}
