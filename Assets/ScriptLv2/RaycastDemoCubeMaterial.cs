using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class RaycastDemoCubeMaterial : MonoBehaviour
{
    private Material DemoCubeMaterialHightlight
    {
        get { return Resources.Load<Material>("Materials/DemoCube/GridOrange"); }
    }
    private Material DemoCubeMaterialActive
    {
        get { return Resources.Load<Material>("Materials/DemoCube/GridYellow"); }
    }

    private void Awake()
    {
        GetComponent<RaycastPointer>().OnDemoCubeInitialize += HandleDemoCubeMaterial;
    }

    void HandleDemoCubeMaterial()
    {
        GetComponent<DemoCube>().HighlightMaterial = DemoCubeMaterialHightlight;
        GetComponent<DemoCube>().ActiveMaterial = DemoCubeMaterialActive;
    }
}
