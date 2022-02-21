using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDemoCubeMaterial : MonoBehaviour
{
    private RaycastPointer raycastPointer;
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
        raycastPointer = GetComponent<RaycastPointer>();
        raycastPointer.OnDemoCubeInitialize += OnClicked;
    }

    void OnClicked()
    {
        raycastPointer.demoCube.HighlightMaterial = DemoCubeMaterialHightlight;
        raycastPointer.demoCube.ActiveMaterial = DemoCubeMaterialActive;
    }
}
