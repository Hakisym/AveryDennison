
using UnityEngine;
using UnityEngine.UI;

public class UIOverlay : MonoBehaviour
{
    void Start()
    {
        Material material = new Material(Shader.Find("UI/Overlay"));
        material.renderQueue = 3010;
        MaskableGraphic[] maskableGraphics = transform.GetComponentsInChildren<MaskableGraphic>();
        if (maskableGraphics.Length > 0)
        {
            for (int i = 0; i < maskableGraphics.Length; i++)
            {
                if (maskableGraphics[i].material.shader == Shader.Find("UI/Default") || maskableGraphics[i].material == null)
                {
                    maskableGraphics[i].material = material;
                }
            }
        }
    }
}
