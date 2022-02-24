using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClickedRods : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<RaycastPointer>().OnRaycastClicked += HandleClickedRods;
    }

    void HandleClickedRods(PointerEventData pointerEvent)
    {
        gameObject.SetActive(false);
        InventoryList.instance.UICanvas.Find("04_ElectrostaticRods").gameObject.SetActive(true);
    }
}
