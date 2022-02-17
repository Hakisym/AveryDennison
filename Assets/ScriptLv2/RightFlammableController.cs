using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFlammableController : MonoBehaviour
{
    private SelectorUIController selectorUIController;

    private void Awake()
    {
        selectorUIController = GetComponent<SelectorUIController>();
        selectorUIController.OnRightButtonSelect += RightFlammableObject;
    }

    void RightFlammableObject()
    {

    }
}
