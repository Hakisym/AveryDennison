using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class PotCollider : MonoBehaviour
{
    public GameObject Glue;
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GrabHose")
        {
            Debug.Log("Collide with Pot inside");
            ColliderTrigger.instance.HoseCollide();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TripCollider")
        {
            Debug.Log("Start Tripping");
            //other.gameObject.SetActive(false);
            //this.GetComponent<JointHelper>().LockYPosition = false;
            ////this.GetComponent<JointHelper>().LockZRotation = false;
            //this.GetComponent<JointHelper>().enabled = false;
            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.0767978f, transform.position.z);
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);
            this.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            Animator.enabled = true;
            Glue.SetActive(true);
        }
    }

    
}
