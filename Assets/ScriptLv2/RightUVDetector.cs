using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightUVDetector : MonoBehaviour
{
    private IButton buttonUIController;

    private void Awake()
    {
        buttonUIController = GetComponent<IButton>();
        buttonUIController.OnRightButtonClicked += ClickedRightUVDetector;
    }

    void ClickedRightUVDetector()
    {
        //Highlight Ventilation

    }
}
