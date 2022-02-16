using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public interface IButton
{
    Sprite HighlightBorderImage { get; }
    Action OnRightButtonClicked { get; set; }
    Action OnWrongButtonClicked { get; set; }
    void RightButton(Button button);
    void WrongButton(Button button);
}

public class ButtonUIController : MonoBehaviour,IButton
{
    private int WrongButtonClicked;

    public Sprite HighlightBorderImage { 
        get 
        { 
            return Resources.Load<Sprite>("Sprite/TitleBorder"); 
        } 
    }

    public Action OnRightButtonClicked { get; set; }
    public Action OnWrongButtonClicked { get; set; }

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
