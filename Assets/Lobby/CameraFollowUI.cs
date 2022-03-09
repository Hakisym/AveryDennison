using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(FindObjectOfType<CharacterController>().transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
