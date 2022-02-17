using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDemoCubeMaterial : MonoBehaviour
{
    private RaycastPointer raycastPointer;
    public Material[] DemoCubeMaterials
    {
        get { return Resources.LoadAll<Material>("Materials/DemoCube"); }
    }

    private void Awake()
    {
        raycastPointer = GetComponent<RaycastPointer>();
        raycastPointer.OnDemoCubeInitialize += OnClicked;
    }

    void OnClicked()
    {
        raycastPointer.demoCube.HighlightMaterial = DemoCubeMaterials[Random.Range(0, DemoCubeMaterials.Length)];
        raycastPointer.demoCube.ActiveMaterial = DemoCubeMaterials[Random.Range(0, DemoCubeMaterials.Length)];
    }
}
