using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using BNG;

public class Touch3s : MonoBehaviour
{
    float TouchTime = 0;
    public GameObject Vendor;
    public GameObject Door1;
    public GameObject Door2;
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
        if (other.gameObject.tag == "Collider")
        {
            if (TouchTime < 3f)
            {
                TouchTime += Time.deltaTime;
                Debug.Log("Touching Ball");
            }
            else
            {
                //AudioMain.instance.EventPlayClip(1, false);
                this.GetComponentInParent<HighlightEffect>().enabled = false;
                this.GetComponent<SphereCollider>().enabled = false;
                Vendor.GetComponent<HighlightEffect>().enabled = true;
                Vendor.GetComponent<BoxCollider>().enabled = true;
                Door1.GetComponent<Animator>().enabled = true;
                Door2.GetComponent<Animator>().enabled = true;
            }
            
        }
    }
}
