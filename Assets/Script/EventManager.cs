using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class _UnityEventFloat : UnityEvent<float> { }

public class EventManager : MonoBehaviour
{
    [Header("Here's a cool event! Drag anything here!")]
    public UnityEvent OnStart;
    public UnityEvent OnRigCollide;
    public UnityEvent OnEnvCollide;
    // Start is called before the first frame update
    void Start()
    {
        OnStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RigHand")
        {
            OnRigCollide.Invoke();
        }
        if (collision.gameObject.tag == "InteriorEnvironment")
        {
            OnEnvCollide.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RigHand")
        {
            OnRigCollide.Invoke();
        }
        if (other.gameObject.tag == "InteriorEnvironment")
        {
            OnEnvCollide.Invoke();
        }
    }

    public void DisableRigCollideEvents(EventManager events)
    {
        int gCount = events.OnRigCollide.GetPersistentEventCount();
        for (int i = 0; i < gCount; i++)
        {
            events.OnRigCollide.SetPersistentListenerState(i, UnityEventCallState.Off);
        }
    }
}
