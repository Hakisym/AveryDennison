using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMainframeController : MonoBehaviour
{
    private IButton buttonUIController;

    private void Awake()
    {
        buttonUIController = GetComponent<IButton>();
        buttonUIController.OnRightButtonClicked += ClickedRightMainFrame;
    }

    void ClickedRightMainFrame()
    {
        //UV highlight

    }
}
