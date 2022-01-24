using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.UI;

public class GameManagerLv3 : MonoBehaviour
{
    public static GameManagerLv3 instance;
    public GameObject modelRig;
    public GameObject[] LevelColliders;
    public GameObject WarningIcon;
    public Text text1;
    public UnityEngine.UI.Button button1;
    private float power = 3;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        modelRig.SetActive(true);
    }

    public void ShowTemperature()
    {
        text1.gameObject.SetActive(true);
        WarningIcon.SetActive(true);
        StartCoroutine(TemperatureDown());
    }

    float Flip(float t)
    {
        return 1 - t;
    }

    float EaseOut(float t)
    {
        return Flip(Mathf.Pow(Flip(t), power));
    }

    IEnumerator TemperatureDown()
    {
        float startTime = 0;
        float temp;
        bool isEqual = false;
        while (startTime < 30)
        {
            temp = Mathf.Lerp(220, 30, EaseOut(startTime / 30));
            temp.ToString("F0");
            text1.text = string.Format("{0:F0}°C", temp);
            if(temp<=50 && !isEqual)
            {
                LevelColliders[0].SetActive(false);
                LevelColliders[1].SetActive(true);
                WarningIcon.SetActive(false);
                isEqual = true;
            }
            startTime += Time.deltaTime;
            yield return null;
        }
        text1.transform.parent.gameObject.SetActive(false);
    }
}
