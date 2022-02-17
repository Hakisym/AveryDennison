using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

public class SuitController : MonoBehaviour
{
    private IButton buttonUIController;

    private void Awake()
    {
        buttonUIController = GetComponent<IButton>();
        buttonUIController.OnRightButtonClicked += ClickedRightSuit;
    }

    void ClickedRightSuit()
    {
        HandModelSelector modelSelector = GameObject.FindObjectOfType<HandModelSelector>();
        modelSelector.ChangeHandsModel(1, false);
    }
}
