using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BNG;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class RaycastPointer : MonoBehaviour
{
    public Action OnPointerEventsInitialize = () => { };
    public Action OnDemoCubeInitialize = () => { };
    public UnityAction<PointerEventData> OnRaycastClicked = delegate { };

    private void Awake()
    {
        gameObject.AddComponent<DemoCube>();
    }

    private void Start()
    {
        OnDemoCubeInitialize();
        OnPointerEventsInitialize();
        GetComponent<PointerEvents>().OnPointerClickEvent.AddListener(OnRaycastClicked);
    }
}
