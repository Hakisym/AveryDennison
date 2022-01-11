using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using BNG;

public class Touch3s : MonoBehaviour
{
    float TouchTime = 0;
    public GameObject Vendor;
    public GameObject VideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.gameObject.name == "RightController")
        {
            if (TouchTime < 3f )
            {
                TouchTime += Time.deltaTime;
                Debug.Log("Touching Ball");
                InputBridge.Instance.VibrateController(0.3f, 0.1f, 0.1f, ControllerHand.Right);
            }
            else
            {
                //AudioMain.instance.EventPlayClip(1, false);
                this.GetComponentInParent<HighlightEffect>().enabled = false;
                this.GetComponent<SphereCollider>().enabled = false;
                Vendor.GetComponent<HighlightEffect>().enabled = true;
                Vendor.GetComponent<BoxCollider>().enabled = true;
            }
        }
        if (other.transform.parent.gameObject.name == "LeftController")
        {
            if (TouchTime < 3f)
            {
                TouchTime += Time.deltaTime;
                Debug.Log("Touching Ball");
                InputBridge.Instance.VibrateController(0.3f, 0.1f, 0.1f, ControllerHand.Left);
            }
            else
            {
                //AudioMain.instance.EventPlayClip(1, false);
                this.GetComponentInParent<HighlightEffect>().enabled = false;
                this.GetComponent<SphereCollider>().enabled = false;
                Vendor.GetComponent<HighlightEffect>().enabled = true;
                Vendor.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
