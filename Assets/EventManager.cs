using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class _UnityEventFloat : UnityEvent<float> { }

public class EventManager : MonoBehaviour
{
    [Header("Here's a cool event! Drag anything here!")]
    public UnityEvent OnStart;
    // Start is called before the first frame update
    void Start()
    {
        OnStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
