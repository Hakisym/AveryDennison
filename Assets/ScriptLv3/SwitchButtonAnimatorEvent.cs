using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;

public class SwitchButtonAnimatorEvent : MonoBehaviour
{
    public void AnimatorEventOnSwitch()
    {
        transform.parent.Find("SnapPoint").gameObject.SetActive(true);

        GetComponentInParent<HighlightEffect>().ProfileLoad(Resources.Load<HighlightProfile>("Profile/SwitchButtonAnimationTriggers"));
    }
}
