using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongButtonController : MonoBehaviour
{
    private ButtonUIController buttonUIController;

    private void Awake()
    {
        buttonUIController = GetComponent<ButtonUIController>();
        buttonUIController.OnWrongButtonClicked += ClickedWrongButton;
    }

    void ClickedWrongButton()
    {
        foreach (Button _button in GetComponentsInChildren<Button>())
        {
            for (int i = 0; i < _button.onClick.GetPersistentEventCount(); i++)
            {
                if (_button.onClick.GetPersistentMethodName(i) == "RightButton")
                    _button.GetComponent<Image>().sprite = buttonUIController.HighlightBorderImage;
            }
        }
    }
}
