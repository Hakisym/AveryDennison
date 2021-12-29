using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class PotCollider : MonoBehaviour
{
    public GameObject Glue;
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
            this.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            Animator.enabled = true;
            Glue.SetActive(true);
            Glue.transform.parent.GetComponent<BoxCollider>().isTrigger = true;
        }

    }
    
}
