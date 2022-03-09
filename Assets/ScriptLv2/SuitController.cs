using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

public class SuitController : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<IButton>().OnRightButtonClicked += ClickedRightSuit;
    }

    void ClickedRightSuit()
    {
        HandModelSelector modelSelector = GameObject.FindObjectOfType<HandModelSelector>();
        modelSelector.ChangeHandsModel(1, false);
        InventoryList.instance.RaycastObject.Find("01_Mainframe").gameObject.SetActive(true);
        AudioMain.instance.PlayDelayClip(6, 5);

    }
}
