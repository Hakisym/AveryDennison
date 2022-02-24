using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;

public class SelectFlammableObject : SelectorUIController
{
    public override void RightButton(HighlightEffect highlightEffect)
    {
        highlightEffect.gameObject.SetActive(false);
        OnRightButtonSelect();
    }

    private void Update()
    {
        if (GetComponentInChildren<HighlightEffect>() == null)
        {
            InventoryList.instance.HighlightObjects.Find("01_TrashCan").gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
