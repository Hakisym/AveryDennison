using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

interface IButton
{
    public Action OnRightButtonClicked { get; set; }
    public Action OnWrongButtonClicked { get; set; }
    public void RightButton(Button button);
    public void WrongButton(Button button);
}

public class ButtonUIController : MonoBehaviour, IButton
{
    public Action OnRightButtonClicked { get; set; } = () => { };
    public Action OnWrongButtonClicked { get; set; } = () => { };

    private int WrongButtonClicked;

    public void RightButton(Button button)
    {
        gameObject.SetActive(false);
        OnRightButtonClicked();
    }

    public void WrongButton(Button button)
    {
        button.gameObject.SetActive(false);
        WrongButtonClicked++;
        if(WrongButtonClicked>=2)
            OnWrongButtonClicked();
    }
}
