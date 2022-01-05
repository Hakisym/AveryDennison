using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.EventSystems;

public class CanController : MonoBehaviour
{
    public PointerEvents[] PEvents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHovering(PointerEventData eventData)
    {
        foreach(var item in PEvents)
        {
            item.OnPointerEnterEvent.Invoke(eventData);
        }
    }

    
    public void ResetHovering(PointerEventData eventData)
    {
        foreach(var item in PEvents)
        {
            item.OnPointerExitEvent.Invoke(eventData);
        }
    }

    public void SetActive(PointerEventData eventData)
    {
        foreach (var item in PEvents)
        {
            item.OnPointerDownEvent.Invoke(eventData);
        }
    }

    public void SetInactive(PointerEventData eventData)
    {
        foreach (var item in PEvents)
        {
            item.OnPointerUpEvent.Invoke(eventData);
        }
    }

    public void PlayAnime()
    {
        foreach(Animator item in GetComponentsInChildren<Animator>())
        {
            item.enabled = true;
        }
    }
}
