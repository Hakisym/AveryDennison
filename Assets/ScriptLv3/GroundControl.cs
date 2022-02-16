using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    private Transform PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = FindObjectOfType<CharacterController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerController.position + new Vector3(0, -0.5f, 0); 
    }
}
