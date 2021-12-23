using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class PotCollider : MonoBehaviour
{
    public GameObject Glue;
    public Animator Animator;
    private int Count = 0;
    private bool Lerp;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lerp)
        {
            StartCoroutine("LerpHose");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GrabHose")
        {
            if(Count == 0)
            {
                Debug.Log("Collide with Pot inside X 1");
                ColliderTrigger.instance.HoseCollide();
                Count++;
            }
            else
            {
                Debug.Log("Collide with Pot inside X 2");
                ColliderTrigger.instance.HoseCollide();
                Lerp = true;
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
        }

        //if (other.gameObject.name == "GrabHose")
        //{
        //    if (Count == 0)
        //    {
        //        Debug.Log("Collide with Pot inside X 1");
        //        ColliderTrigger.instance.HoseCollide();
        //        Count++;
        //    }
        //    else
        //    {
        //        Debug.Log("Collide with Pot inside X 2");
        //        ColliderTrigger.instance.HoseCollide();
        //        Lerp = true;
        //        Count = 0;
        //    }

        //}

    }
    IEnumerator LerpHose()
    {
        ColliderTrigger.instance.LerpPosition();
        yield return new WaitForSeconds(4f);
        Lerp = false;
    }
}
