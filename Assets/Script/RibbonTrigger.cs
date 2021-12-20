using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;

public class RibbonTrigger : MonoBehaviour
{
    public GameObject RopeParent;
    public HighlightEffect Twin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Tape")
        {
            RopeParent.transform.GetChild(3).GetComponent<MeshRenderer>().enabled = true;
            GetComponent<HighlightEffect>().enabled = false;
            Twin.enabled = true;
        }
    }

    public void GrabTape()
    {
        GetComponent<HighlightEffect>().enabled = true;
    }
}
