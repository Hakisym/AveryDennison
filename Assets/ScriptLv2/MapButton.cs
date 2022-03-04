using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    private int _buttonCount;

    public void RightButton()
    {
        gameObject.SetActive(false);
        //Insert Audio
    }

    public void WrongButton(GameObject Button)
    {
        if (_buttonCount == 0)
        {
            //Insert Audio
            Button.SetActive(false);
            _buttonCount++;
        }
        else
        {
            //Insert Audio
            foreach (var item in GetComponentsInChildren<Button>())
            {
                //Disable all Buttons except the correct one
                if (item.gameObject.name == "ButtonA") { continue; }
                item.gameObject.SetActive(false);
            }
            ColorBlock cb = new ColorBlock();
            cb.normalColor = Color.yellow;
            cb.highlightedColor = Color.green;
            cb.pressedColor = Color.blue;
            cb.disabledColor = Color.black;
            cb.colorMultiplier = 1.0f;
            transform.Find("ButtonA").GetComponent<Button>().colors = cb;
            StartCoroutine(AutoHide3());
        }
    }


    protected IEnumerator AutoHide3()
    {
        yield return new WaitForSeconds(5);
        RightButton();
    }
}
