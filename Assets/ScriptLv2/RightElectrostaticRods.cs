using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightElectrostaticRods : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<IButton>().OnRightButtonClicked += ClickedRightElectrostaticRods;
    }

    internal virtual void ClickedRightElectrostaticRods()
    {
        InventoryList.instance.RaycastObject.Find("05_WaterSprayHumidifier").gameObject.SetActive(true);
        AudioMain.instance.PlayDelayClip(19, 22);
    }
}
