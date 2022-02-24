using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    public static InventoryList instance;

    public Transform UICanvas
    {
        get { return GameObject.FindGameObjectWithTag("UICanvas").transform; }
    }
    public Transform Selector
    {
        get { return GameObject.FindGameObjectWithTag("Selector").transform; }
    }
    public Transform RaycastObject
    {
        get { return GameObject.FindGameObjectWithTag("RaycastObject").transform; }
    }
    public Transform HighlightObjects
    {
        get { return GameObject.FindGameObjectWithTag("HighlightObject").transform; }
    }

    private void Awake()
    {
        instance = this;
    }
}
