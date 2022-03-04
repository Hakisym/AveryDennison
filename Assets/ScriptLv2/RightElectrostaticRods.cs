using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightElectrostaticRods : MonoBehaviour
{
    private IButton buttonUIController;

    private void Awake()
    {
        buttonUIController = GetComponent<IButton>();
        buttonUIController.OnRightButtonClicked += ClickedRightElectrostaticRods;
    }

    internal virtual void ClickedRightElectrostaticRods()
    {
        InventoryList.instance.RaycastObject.Find("05_WaterSprayHumidifier").gameObject.SetActive(true);
    }
}
