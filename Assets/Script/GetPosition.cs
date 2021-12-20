using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{
    private Transform Transform;
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
        Transform = Glue.transform.parent.parent;
        LeverC.transform.position = Transform.position;
        Transform = Glue.transform.parent.parent.parent;
        LeverC.transform.localEulerAngles = new Vector3(Transform.localEulerAngles.x - 90, Transform.localEulerAngles.y + 90, Transform.localEulerAngles.z);
        GrabPoint.transform.parent = Hinge.transform;
        GrabPoint.transform.localScale = Vector3.one;
        GrabPoint.transform.localEulerAngles = new Vector3(Transform.localEulerAngles.x + 90, Transform.localEulerAngles.y - 90, Transform.localEulerAngles.z);
        Glue.transform.parent.parent = Hinge.transform;
        Glue.transform.parent = LeverC.transform.parent;

    }
}
