using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRightSpray : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SelectorUIController>().OnRightButtonSelect += HandleRightSpray;
    }

    void HandleRightSpray()
    {
        InventoryList.instance.Selector.Find("06_FlammableObject").gameObject.SetActive(true);
    }
}
