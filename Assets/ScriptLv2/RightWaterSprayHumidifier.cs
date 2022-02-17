using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWaterSprayHumidifier : MonoBehaviour
{
    private IButton buttonUIController;

    private void Awake()
    {
        buttonUIController = GetComponent<IButton>();
        buttonUIController.OnRightButtonClicked += ClickedRightWaterSprayHumidifier;
    }

    void ClickedRightWaterSprayHumidifier()
    {
        //Highlight Flammable Objects

    }
}
