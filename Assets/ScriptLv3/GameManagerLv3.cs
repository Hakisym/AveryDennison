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
        AudioMain.instance.PlayDoubleDelay(1,2,3);
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
            text1.text = string.Format("{0:F0}¡ãC", temp);
            if(temp<=50 && !isEqual)
            {
                isEqual = true;
                LevelColliders[0].SetActive(false);
                LevelColliders[1].SetActive(true);
                HMDIcon[0].SetActive(false);
                highlights[0].enabled = true;
                AudioMain.instance.EventPlayClip(4, false);
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
        //Insert Audio Clip
        AudioMain.instance.EventPlayClip(5, false);
        LockCount++;
        if (LockCount == 2)
        {
            HMDIcon[1].SetActive(false);
            UI[1].SetActive(true);
            //Insert Audio Clip
            AudioMain.instance.EventPlayClip(17, false);
        }
    }
    #endregion

    #region UI Popup PPE Uniform
    public void RightPPE()
    {
        UI[1].SetActive(false);
        GeneratePPE();
        UI[2].SetActive(true);
        AudioMain.instance.PlayDelayClip(7, 9);
    }

    public void WrongPPE(GameObject Button)
    {
        AudioMain.instance.EventPlayClip(8, false);
        if (PPECount == 0)
        {
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
        modelSelector.ChangeHandsModel(1, false);
    }
    protected IEnumerator AutoHide2()
    {
        yield return new WaitForSeconds(5);
        RightPPE();
    }
    #endregion

    #region AudioInstance
    public void PlayEventClip(int clip)
    {
        AudioMain.instance.EventPlayClip(clip, false);
    }

    public void PlayDoubleClip(int clip)
    {
        AudioMain.instance.PlayDelayClip(clip, clip + 1);
    }
    #endregion

}
