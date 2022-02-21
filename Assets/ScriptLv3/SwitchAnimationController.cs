using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchAnimationController : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<RaycastPointer>().OnRaycastClicked += HandleTwistButtonAnimation;
    }

    void HandleTwistButtonAnimation(PointerEventData eventData)
    {
        GetComponentInParent<Animator>().enabled = true;
        AudioMain.instance.EventPlayClip(6, false);
    }
}
