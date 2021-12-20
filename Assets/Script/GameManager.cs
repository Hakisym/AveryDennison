using BNG;
using HighlightPlus;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HighlightPlus;

public class GameManager : MonoBehaviour
{
    public Canvas Arrow1;
    public Canvas Ring1;
    public Canvas Ring2;
    public Canvas Counter;

    public GameObject ButtonSet1;
    public GameObject ElecBall;
    public GameObject Vendor;
    public GameObject Case;
    public GameObject CubeCollider;
    public GameObject VideoPlayer;

    public TextMeshProUGUI Text1;


    private int Unicount = 0;
    private bool IsEightSeconds = false;
    private bool IsSnapClip = false;

    // Start is called before the first frame update
    void Start()
    {
        Initialised();
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


    public void Initialised()
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
        Arrow1.gameObject.SetActive(true);
        CubeCollider.GetComponent<BoxCollider>().enabled = true;
        VideoPlayer.SetActive(false);
    }

    public void ClickedBlowButton()
    {
        if (Ring1.gameObject.activeSelf)
        {
            Debug.Log("Clicked Blow Button");
            Counter.gameObject.SetActive(true);
            Ring1.gameObject.SetActive(false);
            StartCoroutine(Timer());
        }
        
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
                else if (i == 1)
                {
                    Text1.text = "Countdown:" + i + " Minute";
                }
                else
                {
                    Counter.gameObject.SetActive(false);
                    Ring2.gameObject.SetActive(true);
                    IsEightSeconds = true;
                }

                yield return new WaitForSeconds(1);
            }
    }

    public void ClickedPowerButton()
    {
        if (IsEightSeconds&& Ring2.gameObject.activeSelf)
        {
            Ring2.gameObject.SetActive(false);
            Debug.Log("Clicked Power Button");

        }
        else
        {
            //Audio
        }
    }

    public void Ongrab(GameObject Case)
    {
        foreach(var item in Case.GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = true;
        }
    }

    public void OnNotGrab(GameObject Clip)
    {

    }

    public void OnSnapClip()
    {
        foreach (var item in Case.GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = false;
        }
    }

    public void PotRight()
    {
        //audio
        Debug.Log("Right snap point");
    }

    public void PotWrong()
    {
        Debug.Log("Wrong snap point");
        ColliderTrigger.instance.HoseCollide();
    }
}
