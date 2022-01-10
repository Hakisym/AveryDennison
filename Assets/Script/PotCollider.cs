using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class PotCollider : MonoBehaviour
{
    public GameObject Glue;
    public Collider Walkie;
    public Animator Animator;
    private int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GrabHose")
        {
            if (Count == 0)
            {
                Debug.Log("Collide with Pot inside X 1");
                ColliderTrigger.instance.HoseCollide();
                Count++;
            }
            else
            {
                Debug.Log("Collide with Pot inside X 2");
                ColliderTrigger.instance.HoseCollide();
                ColliderTrigger.instance.LerpPosition();
                Count = 0;
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TripCollider")
        {
            Debug.Log("Start Tripping");
            //Stop moving the handle and kill the Snappoint
            this.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            //start both animations and cancel box collider
            Animator.enabled = true;
            Glue.SetActive(true);
            Glue.transform.parent.GetComponent<BoxCollider>().isTrigger = true;

            GameManager.instance.GrabbableCollider(GameManager.instance.Clipper, false);
            GameManager.instance.GrabbableCollider(GameManager.instance.GrabHose, false);
            GameManager.instance.GrabbableCollider(Walkie, true);
            Walkie.GetComponent<HighlightPlus.HighlightEffect>().enabled = true;
        }

    }
    
}
