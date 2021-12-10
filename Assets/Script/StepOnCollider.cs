using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepOnCollider : MonoBehaviour
{
    public Canvas DoubleA;
    public Canvas FourA;
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
        if (other.gameObject.tag == "Collider")
        {
            Debug.Log("Enter Zone 1");
            DoubleA.gameObject.SetActive(false);
            FourA.gameObject.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
