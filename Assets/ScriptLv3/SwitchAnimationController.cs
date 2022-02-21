using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchAnimationController : MonoBehaviour
{
    private RaycastPointer raycastPointer;

    private void Awake()
    {
        raycastPointer = GetComponent<RaycastPointer>();
        raycastPointer.OnRaycastClicked += ActivateTwistButtonAnimation;
    }

    void ActivateTwistButtonAnimation(PointerEventData eventData)
    {
        GetComponentInParent<Animator>().enabled = true;
        AudioMain.instance.EventPlayClip(6, false);
    }
}
