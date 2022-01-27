using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.UI;
using HighlightPlus;

public class GameManagerLv3 : MonoBehaviour
{
    public static GameManagerLv3 instance;
    public GameObject[] modelRig;
    public GameObject[] LevelColliders;
    public GameObject[] HMDIcon;
    public GameObject[] UI;
    public GameObject ButtonSet2;
    public HighlightEffect[] highlights;
    public Text text1;
    public UnityEngine.UI.Button button1;
    public HandModelSelector modelSelector;
    public ParticleSystem Fire;
    private float power = 3;
    private int PPECount = 0;
    private int LockCount = 0;
    
    
    void Start()
    {
        instance = this;
        modelRig[0].SetActive(true);
    }


    #region Level1
    public void ShowTemperature()
    {
        UI[0].SetActive(true);
        HMDIcon[0].SetActive(true);
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
                isEqual = true;
                LevelColliders[0].SetActive(false);
                LevelColliders[1].SetActive(true);
                HMDIcon[0].SetActive(false);
                highlights[0].enabled = true;
            }
            startTime += Time.deltaTime;
            yield return null;
        }
        UI[0].SetActive(false);
    }
    #endregion

    #region Locktwo
    public void CountLock()
    {
        LockCount++;
        if (LockCount == 2)
        {
            HMDIcon[1].SetActive(false);
            UI[1].SetActive(true);
        }
    }
    #endregion

    #region UI Popup PPE Uniform
    public void RightPPE()
    {
        UI[1].SetActive(false);
        GeneratePPE();
        UI[2].SetActive(true);
        //AudioMain.instance.EventPlayClip(26, false);
    }

    public void WrongPPE(GameObject Button)
    {
        if (PPECount == 0)
        {
            //AudioMain.instance.EventPlayClip(25, false);
            Button.SetActive(false);
            PPECount++;
        }
        else
        {
            Button.SetActive(false);
            PPECount = 0;
            StartCoroutine(AutoHide2());
        }
    }

    public void GeneratePPE()
    {
        modelRig[0].SetActive(false);
        modelRig[1].SetActive(true);
        modelSelector.ChangeHandsModel(2, false);
    }
    protected IEnumerator AutoHide2()
    {
        yield return new WaitForSeconds(5);
        RightPPE();
    }
    #endregion

    
}
