using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public UnityEvent pointerEvents;
    public DemoCube demoCube { get; set; }

    private void Awake()
    {
        
        demoCube = gameObject.AddComponent<DemoCube>();
    }
}
