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

    void ClickedRightElectrostaticRods()
    {
        //Highlight Water spray humidifier

    }
}
