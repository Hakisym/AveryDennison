using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] [Range(0f, 100f)] float lerpTime;
    [SerializeField] Color[] myColors;
    float num = 0;
    int colorIndex = 0;
    int len;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        len = myColors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, myColors[colorIndex], lerpTime * Time.deltaTime);

        num = Mathf.Lerp(num, 1f, lerpTime * Time.deltaTime);

        if (num > .9f)
        {
            num = 0;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
