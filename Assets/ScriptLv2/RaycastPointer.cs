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
        pointerEvents = gameObject.AddComponent<PointerEvents>();
        demoCube = gameObject.AddComponent<DemoCube>();
    }

    private void Start()
    {
        pointerEvents.OnPointerClickEvent.AddListener(OnRaycastClicked);
        OnDemoCubeInitialize();
        OnPointerEventsInitialize();
    }

}
