using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointerController : MonoBehaviour
{
    private RaycastPointer raycastPointer;

    private void Awake()
    {
        raycastPointer = GetComponent<RaycastPointer>();
        raycastPointer.OnPointerEventsInitialize += OnClicked;
    }

    void OnClicked()
    {
        raycastPointer.pointerEvents.OnPointerEnterEvent.AddListener(raycastPointer.demoCube.SetHovering);
        raycastPointer.pointerEvents.OnPointerExitEvent.AddListener(raycastPointer.demoCube.ResetHovering);
        raycastPointer.pointerEvents.OnPointerDownEvent.AddListener(raycastPointer.demoCube.SetActive);
        raycastPointer.pointerEvents.OnPointerUpEvent.AddListener(raycastPointer.demoCube.SetInactive);
    }
}
