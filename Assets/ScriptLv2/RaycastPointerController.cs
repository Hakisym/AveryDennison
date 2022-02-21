using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointerController : MonoBehaviour
{
    private PointerEvents pointerEvents;
    private DemoCube demoCube;

    private void Awake()
    {
        GetComponent<RaycastPointer>().OnPointerEventsInitialize += HandlePointerEventListener;
    }

    void HandlePointerEventListener()
    {
        pointerEvents = GetComponent<PointerEvents>();
        demoCube = GetComponent<DemoCube>();

        pointerEvents.OnPointerEnterEvent.AddListener(demoCube.SetHovering);
        pointerEvents.OnPointerExitEvent.AddListener(demoCube.ResetHovering);
        pointerEvents.OnPointerDownEvent.AddListener(demoCube.SetActive);
        pointerEvents.OnPointerUpEvent.AddListener(demoCube.SetInactive);
    }
}
