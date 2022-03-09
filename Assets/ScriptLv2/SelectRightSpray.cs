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
        AudioMain.instance.PlayDelayClip(23, 25);
        foreach (var item in GrabbableFlammableObjects)
            item.SetActive(true);
    }
}
