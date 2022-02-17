using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightVentilationController : MonoBehaviour
{
    private IButton buttonUIController;

    private void Awake()
    {
        buttonUIController = GetComponent<IButton>();
        buttonUIController.OnRightButtonClicked += ClickedRightVentilation;
    }

    void ClickedRightVentilation()
    {
        //Highlight Clipper

    }
}
