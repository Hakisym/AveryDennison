using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointerController : MonoBehaviour
{
    private RaycastPointer raycastPointer;
    private PointerEvents pointerEvents;
    private DemoCube demoCube;

    private void Awake()
    {
        raycastPointer = GetComponent<RaycastPointer>();
        raycastPointer.OnPointerEventsInitialize += OnClicked;
    }

    void OnClicked()
    {
        pointerEvents = GetComponent<PointerEvents>();
        demoCube = GetComponent<DemoCube>();
        if (pointerEvents.OnPointerEnterEvent!=null)
        {
            Debug.Log(pointerEvents.OnPointerEnterEvent);
        }

        pointerEvents.OnPointerEnterEvent.AddListener(demoCube.SetHovering);
        pointerEvents.OnPointerExitEvent.AddListener(demoCube.ResetHovering);
        pointerEvents.OnPointerDownEvent.AddListener(demoCube.SetActive);
        pointerEvents.OnPointerUpEvent.AddListener(demoCube.SetInactive);
    }
}
