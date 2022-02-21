using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BNG;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class RaycastPointer : MonoBehaviour
{
    public Action OnPointerEventsInitialize { get; set; }
    public Action OnDemoCubeInitialize { get; set; }
    public UnityAction<PointerEventData> OnRaycastClicked { get; set; }
    public PointerEvents pointerEvents { get; set; }
    public DemoCube demoCube { get; set; }

    private void Awake()
    {
        pointerEvents =GetComponent<PointerEvents>();
        demoCube = GetComponent<DemoCube>();
    }

    private void Start()
    {
        OnDemoCubeInitialize();
        OnPointerEventsInitialize();
        if (OnRaycastClicked != null)
        {
            pointerEvents.OnPointerClickEvent.AddListener(OnRaycastClicked);
        }
    }
}
