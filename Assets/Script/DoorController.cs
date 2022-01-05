using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator DoorLeft;
    public Animator DoorRight;
    public bool Glue;
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
        if (other.gameObject.tag == "RigHand" && GetPosition.instance.Retreat == false)
        {
            DoorLeft.SetBool("Enter", true);
            DoorLeft.SetBool("Exit", false);
            DoorRight.SetBool("Enter", true);
            DoorRight.SetBool("Exit", false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RigHand" && GetPosition.instance.Leak == false)
        {
            DoorLeft.SetBool("Enter", false);
            DoorLeft.SetBool("Exit", true);
            DoorRight.SetBool("Enter", false);
            DoorRight.SetBool("Exit", true);
        }
    }

}
