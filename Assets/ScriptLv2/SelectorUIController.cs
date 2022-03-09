using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using BNG;
using HighlightPlus;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public interface ISelector
{
    Action OnRightButtonSelect { get; set; }
    Action OnWrongButtonSelectOnce { get; set; }
    Action OnWrongButtonSelectTwice { get; set; }
    void RightButton(HighlightEffect highlightEffect);
    void WrongButton(HighlightEffect highlightEffect);
}

public class SelectorUIController : MonoBehaviour,ISelector
{
    private int WrongButtonSelect;

    public Action OnRightButtonSelect { get; set; } = delegate { };
    public Action OnWrongButtonSelectOnce { get; set; } = delegate { };
    public Action OnWrongButtonSelectTwice { get; set; } = delegate { };

    public virtual void RightButton(HighlightEffect highlightEffect)
    {
        gameObject.SetActive(false);
        OnRightButtonSelect();
    }

    public void WrongButton(HighlightEffect highlightEffect)
    {
        highlightEffect.gameObject.SetActive(false);
        OnWrongButtonSelectOnce();
        WrongButtonSelect++;
        if (WrongButtonSelect >= 2)
            OnWrongButtonSelectTwice();
    }
}
