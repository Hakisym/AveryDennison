using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRightSpray : MonoBehaviour
{
    [SerializeField]
    private GameObject[] GrabbableFlammableObjects;

    private void Awake()
    {
        GetComponent<SelectorUIController>().OnRightButtonSelect += HandleRightSpray;
    }

    void HandleRightSpray()
    {
        InventoryList.instance.HighlightObjects.Find("01_TrashCan").gameObject.SetActive(true);
        foreach (var item in GrabbableFlammableObjects)
            item.SetActive(true);
    }
}
