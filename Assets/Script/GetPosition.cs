using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{
    private Transform transform;
    public GameObject Glue;

    public GameObject LeverC;
    public GameObject Hinge;
    public GameObject GrabPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetTransform()
    {
        transform = Glue.transform.parent.parent;
        LeverC.transform.position = transform.position;
        transform = Glue.transform.parent.parent.parent;
        LeverC.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - 90, transform.localEulerAngles.y + 90, transform.localEulerAngles.z);
        GrabPoint.transform.parent = Hinge.transform;
        GrabPoint.transform.localScale = Vector3.one;
        GrabPoint.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + 90, transform.localEulerAngles.y - 90, transform.localEulerAngles.z);
        Glue.transform.parent.parent = Hinge.transform;
        Glue.transform.parent = LeverC.transform.parent;

    }
}
