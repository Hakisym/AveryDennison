using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using BNG;

public class GlueController : MonoBehaviour
{
    public GameObject Pillow;
    public Material Pillow1;
    public Material Pillow2;
    public Material Pillow3;
    public Material Pillow4;
    public Material[] Pillows;
    Color32 col;
    Color32 colTemp;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        //Pillows = GetComponentsInChildren<MeshRenderer.>();
        col = Pillow2.GetColor("_Color");
        colTemp = col;
        col.a = 225;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SecurePillow()
    {
        Pillow.SetActive(true);
        Pillow.transform.GetChild(0).GetComponent<HighlightEffect>().enabled = true;
        Pillow.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void SnapPhaseOne()
    {
        Pillow.transform.GetChild(4).gameObject.SetActive(false);
        Pillow1.SetColor("_Color",col);
        Pillow.transform.GetChild(5).gameObject.SetActive(true);
    }

    public void SnapPhaseTwo()
    {
        Pillow.transform.GetChild(5).gameObject.SetActive(false);
        Pillow2.SetColor("_Color", col);
        Pillow.transform.GetChild(6).gameObject.SetActive(true);
    }
    public void SnapPhaseThree()
    {
        Pillow.transform.GetChild(6).gameObject.SetActive(false);
        Pillow3.SetColor("_Color", col);
        Pillow.transform.GetChild(7).gameObject.SetActive(true);
    }
    public void SnapPhaseFour()
    {
        Pillow.transform.GetChild(7).gameObject.SetActive(false);
        Pillow4.SetColor("_Color", col);
    }

    public void SnapPhase(int i)
    {
        Pillow.transform.GetChild(i+3).gameObject.SetActive(false);
        Pillows[i-1].SetColor("_Color", col);
        if (i < 4)
        {
            Pillow.transform.GetChild(i+4).gameObject.SetActive(true);
        }
    }
    private void OnApplicationQuit()
    {
        foreach(Material pillow in Pillows)
        {
            pillow.SetColor("_Color", colTemp);
        }
    }
}
