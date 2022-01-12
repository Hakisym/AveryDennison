using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using HighlightPlus;

public class VRRenderScale : MonoBehaviour
{
    public HighlightEffect[] allComponents;
    // Start is called before the first frame update
    void Start()
    {
            allComponents = Resources.FindObjectsOfTypeAll<HighlightEffect>();
            for (int j = 0; j < allComponents.Length; j++)
            {
                Debug.Log(allComponents[j]);
            }

        XRSettings.eyeTextureResolutionScale = 1.5f;
    }
}
