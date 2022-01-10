using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;

public class RibbonTrigger2 : MonoBehaviour
{
    public GameObject RopeParent;
    public HighlightEffect LEL;
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
        if (other.gameObject.name == "Tape")
        {
            RopeParent.transform.GetChild(2).gameObject.SetActive(true);
            RopeParent.transform.GetChild(3).GetComponent<MeshRenderer>().enabled = false;
            GetComponent<HighlightEffect>().enabled = false;
            GameManager.instance.GrabbableCollider(GameManager.instance.LEL, true);
            LEL.enabled = true;
        }
    }
}
