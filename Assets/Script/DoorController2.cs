using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController2 : MonoBehaviour
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
        DoorLeft.SetFloat("Speed", 1);
        DoorLeft.SetBool("Start", true);

        DoorRight.SetFloat("Speed", 1);
        DoorRight.SetBool("Start", true);
    }

    private void OnTriggerExit(Collider other)
    {
        DoorLeft.SetFloat("Speed", -1);
        DoorLeft.SetBool("Start", true);

        DoorRight.SetFloat("Speed", -1);
        DoorRight.SetBool("Start", true);
    }
}
