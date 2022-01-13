using BNG;
using HighlightPlus;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas Arrow1;
    public Canvas Arrow2;
    public Canvas Arrow3;
    public Canvas Ring1;
    public Canvas Ring2;
    public Canvas Counter;

    public GameObject ButtonSet1;
    public GameObject ButtonSet2;
    public GameObject ElecBall;
    public GameObject Vendor;
    public GameObject Case;
    public GameObject CubeCollider;
    public GameObject VideoPlayer;
    public GameObject Glue;
    public GameObject SnapCloth;

    public GameObject modelRig;

    public Animator animator;

    public ParticleSystem fire;

    private GameObject Pillow;
    private GameObject Cloth;

    public TextMeshProUGUI Text1;

    public Collider RigController;
    public Collider Clipper;
    public Collider GrabHose;
    public Collider LEL;
    public Collider SFireExt;
    public Collider YellowBarrel;
    public Collider BFireExt;
    public Collider YellowCap;
    public HighlightEffect FireTong;

    private int Unicount = 0;
    private int PrefabCount_1 = 0;
    private int PrefabCount_2 = 0;
    private int ChemicalCount = 0;
    public bool ReleaseHose = false;
    private bool IsEightSeconds = false;
    private bool IsSnapClip = false;
    private bool SwitchPrefab = false;

    private string prefabName1 = "weidang";
    private string prefabName2 = "FrictionCloth";
    UnityEventCallState state = UnityEventCallState.Off;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ButtonSet1.SetActive(true);
        modelRig.SetActive(true);
    }

    public void RightUniform()
    {
        //AudioMain.instance.EventPlayClip(0, false);
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

    }

    public void SelectVendor()
    {
        Debug.Log("Clicked Vendor");
        Vendor.GetComponent<HighlightEffect>().enabled = false;
        Vendor.GetComponent<BoxCollider>().enabled = false;
        Arrow1.gameObject.SetActive(true);
        CubeCollider.GetComponent<BoxCollider>().enabled = true;
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
            GrabbableCollider(Clipper, true);
            Arrow2.gameObject.SetActive(false);
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
        GrabbableCollider(GrabHose, true);
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

    public void ReleaseRopes()
    {
        ReleaseHose = true;
    }

    public void RightPPE()
    {
        ButtonSet2.SetActive(false);
        GeneratePPE();
    }

    public void WrongPPE(GameObject Button)
    {
        if (Unicount == 0)
        {
            //AudioMain.instance.EventPlayClip(1, false);
            Button.SetActive(false);
            Unicount++;
        }
        else
        {
            //AudioMain.instance.EventPlayClip(1, false);
            Button.SetActive(false);
            Unicount = 0;
            StartCoroutine(AutoHide2());
        }
    }

    public void GeneratePPE()
    {

    }

    protected IEnumerator AutoHide2()
    {
        yield return new WaitForSeconds(5);
        RightPPE();
    }

    public void GenerateStuff()
    {
        if (!SwitchPrefab)
        {
            if (PrefabCount_1 == 0)
            {
                GlueController.instance.SecurePillow();
            }
            Pillow = Instantiate(Resources.Load(prefabName1, typeof(GameObject))) as GameObject;
            Pillow.GetComponent<IgnoreColliders>().CollidersToIgnore.Add(RigController);
            PrefabCount_1++;
        }
        if (PrefabCount_2 < 1 && SwitchPrefab )
        {
            Cloth = Instantiate(Resources.Load(prefabName2, typeof(GameObject))) as GameObject;
            Cloth.transform.parent = GameObject.Find("Obi Solver").transform;
            PrefabCount_2++;
            Glue.GetComponent<HighlightEffect>().enabled = true;
        }

    }

    public void Napkin()
    {
            Glue.transform.GetChild(1).gameObject.SetActive(false);
            Glue.transform.GetChild(2).gameObject.SetActive(false);
            SnapCloth.SetActive(true);
            Glue.transform.GetChild(4).gameObject.SetActive(true);
            HighlightController(YellowBarrel.gameObject, true);
            SwitchPrefab = true;
    }

    public void SnapChemicals(SnapZone snapZone)
    {
        if(snapZone.HeldItem.gameObject.name == "Grab")
        {
            GameObject.Find("FrictionCloth").SetActive(false);
        }
        snapZone.HeldItem.gameObject.SetActive(false);
        snapZone.ReleaseAll();
        ChemicalCount++;
        if (ChemicalCount >= 5)
        {
            animator.SetTrigger("Close");
            ClothDIsappear.instance.Bag.enabled = false;
            fire.gameObject.SetActive(true);
            BFireExt.enabled = true;
            BFireExt.GetComponent<HighlightEffect>().enabled = true;
        }
    }
    
    public void GrabbableCollider(Collider collider,bool choice)
    {
        collider.enabled = choice;
        collider.transform.GetChild(1).gameObject.SetActive(choice);
    }

    public void HighlightController(GameObject gameObject,bool choice)
    {
        gameObject.GetComponent<HighlightEffect>().enabled = choice;
    }

    public void DisableAllEvents(GrabbableUnityEvents events)
    {
        int gCount = events.onGrab.GetPersistentEventCount();
        int rCount = events.onRelease.GetPersistentEventCount();
        for (int i = 0; i< gCount; i++)
        {
            events.onGrab.SetPersistentListenerState(i, state);
        }
        for (int j = 0; j < rCount; j++)
        {
            events.onRelease.SetPersistentListenerState(j, state);

        }

    }
    public void DisableEventsonGrab(GrabbableUnityEvents events)
    {
        int gCount = events.onGrab.GetPersistentEventCount();
        for (int i = 0; i < gCount; i++)
        {
            events.onGrab.SetPersistentListenerState(i, state);
        }
    }

    public void DisablePointerEventonGrab(PointerEvents events)
    {
        int cCount = events.OnPointerClickEvent.GetPersistentEventCount();
        for (int i = 0; i < cCount; i++)
        {
            events.OnPointerClickEvent.SetPersistentListenerState(i, state);
        }
    }

    public void WeiDangScale(Transform _WeiDang)
    {
        _WeiDang.parent.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
