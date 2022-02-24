using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClickedMainframe : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<RaycastPointer>().OnRaycastClicked += HandleClickedMainframe;
    }

    void HandleClickedMainframe(PointerEventData pointerEvent)
    {
        gameObject.SetActive(false);
        InventoryList.instance.UICanvas.Find("01_Mainframe").gameObject.SetActive(true);
    }
}
