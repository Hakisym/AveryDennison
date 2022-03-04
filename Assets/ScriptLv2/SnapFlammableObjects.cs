using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapFlammableObjects : MonoBehaviour
{
    private int Count;
    private SnapZone snapZone;

    private void Awake()
    {
        snapZone = GetComponentInChildren<SnapZone>();
    }

    public void HandleSnapFlammable()
    {
        snapZone.HeldItem.gameObject.SetActive(false);
        snapZone.ReleaseAll();
        Count++;
        if (Count >= 3)
        {
            gameObject.SetActive(false);
            InventoryList.instance.HighlightObjects.Find("02_MediumFlames").gameObject.SetActive(true);
            //Find the Yellow Switch and turn on its component
            GameObject.Find("YellowSwitch").GetComponentInChildren<HighlightPlus.HighlightEffect>().enabled = true;
            GameObject.Find("YellowSwitch").GetComponentInChildren<BoxCollider>().enabled = true;
            //Insert Audio
        }
    }
}
