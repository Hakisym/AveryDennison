using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyDoor : MonoBehaviour
{
    Animator Door;
    private void Awake()
    {
        Door = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RigHand")
        {
            Door.SetBool("Enter", true);
            Door.SetBool("Exit", false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RigHand")
        {
            Door.SetBool("Enter", false);
            Door.SetBool("Exit", true);
        }
    }
}
