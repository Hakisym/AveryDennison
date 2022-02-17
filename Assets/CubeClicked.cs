using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeClicked : MonoBehaviour
{
    private RaycastPointer raycastPointer;

    private void Awake()
    {
        raycastPointer = GetComponent<RaycastPointer>();
        raycastPointer.OnRaycastClicked += test;
    }

    void test(PointerEventData eventData)
    {
        Debug.Log("yeeeeeeeee");
    }
}
