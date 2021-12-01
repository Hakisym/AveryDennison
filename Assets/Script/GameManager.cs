using BNG;
using HighlightPlus;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HighlightPlus;

public class GameManager : MonoBehaviour
{
    public Canvas DoubleA;
    public Canvas SolidA;
    public Canvas SolidA2;
    public Canvas Counter;
    public GameObject ButtonSet1;
    private int Unicount=0;
    public GameObject ElecBall;
    public GameObject Vendor;
    public TextMeshProUGUI Text1;

    private bool IsEightSeconds = false;

    // Start is called before the first frame update
    void Start()
    {
        initialised();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RightUniform()
    {
        //AudioMain.instance.EventPlayClip(0, false);
        //set static ball glowing,collider on
        ElecBall.GetComponentInChildren<HighlightEffect>().enabled = true;
        ElecBall.GetComponentInChildren<SphereCollider>().enabled = true;
        ButtonSet1.SetActive(false);
        GenerateUniform();
    }

    public void WrongUniform(GameObject button)
    {
        if (Unicount==0)
        {
            //AudioMain.instance.EventPlayClip(1, false);
            button.SetActive(false);
            Unicount++;
        }
        else
        {
            //AudioMain.instance.EventPlayClip(1, false);
            button.SetActive(false);
            Unicount = 0;
            StartCoroutine(AutoHide());
        }
    }

    public void GenerateUniform()
    {
        //setactive(true)
    }

    protected IEnumerator AutoHide()
    {
        yield return new WaitForSeconds(5);
        RightUniform();
    }

    protected void OnCollisionStay(Collision collision)
    {
        
    }

    public void initialised()
    {
        ElecBall.GetComponentInChildren<SphereCollider>().enabled = false;
        ElecBall.GetComponentInChildren<HighlightEffect>().enabled = false;
        //Vendor.GetComponent<HighlightEffect>().enabled = false;
        //Vendor.GetComponent<PointerEvents>().enabled = false;
    }

    public void SelectVendor()
    {
        Debug.Log("Clicked Vendor");
        Vendor.GetComponent<HighlightEffect>().enabled = false;
        Vendor.GetComponent<BoxCollider>().enabled = false;
        DoubleA.gameObject.SetActive(true);
    }

    public void ClickedBlowButton()
    {
        Debug.Log("Clicked Blow Button");
        Counter.gameObject.SetActive(true);
        SolidA.gameObject.SetActive(false);
        StartCoroutine(Timer());
    }

    public void ButtonGlow(GameObject Button)
    {
        Button.GetComponent<HighlightEffect>().enabled = true;
    }

    public void ButtonNotGlow(GameObject Button)
    {
        Button.GetComponent<HighlightEffect>().enabled = false;
    }

    protected IEnumerator Timer()
    {
        IsEightSeconds = false;

        for (int i = 8; i >= 0; i--)
        {
            if (i > 1)
            {
                Text1.text = "Countdown:" + i + " Minutes";
            }
            else if(i==1)
            {
                Text1.text = "Countdown:" + i + " Minute";
            }
            else
            {
                Counter.gameObject.SetActive(false);
                SolidA2.gameObject.SetActive(true);
                IsEightSeconds = true;
            }

            yield return new WaitForSeconds(1);
        }
    }

    public void ClickedPowerButton()
    {
        if (!IsEightSeconds)
        {
            //Audio
        }
        else
        {
            SolidA2.gameObject.SetActive(false);
        }
        Debug.Log("Clicked Power Button");
    }
}
