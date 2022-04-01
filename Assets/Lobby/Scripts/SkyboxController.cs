using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    [SerializeField]
    private Material material;
    public void HandleSkybox()
    {
        RenderSettings.skybox = material;
    }
}
