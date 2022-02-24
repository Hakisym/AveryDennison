using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRightUV : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SelectorUIController>().OnRightButtonSelect += HandleRightUV;
    }

    void HandleRightUV()
    {
        InventoryList.instance.RaycastObject.Find("03_Ventilation").gameObject.SetActive(true);
    }
}
