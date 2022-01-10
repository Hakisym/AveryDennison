using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{
    public static GetPosition instance;
    private Transform Trans;
    public GameObject Glue;

    public GameObject LeverC;
    public GameObject Hinge;
    public bool Leak;
    public bool Retreat;
    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetTransform()
    {
        Trans = this.transform;//get animation transform
        LeverC.transform.position = Trans.position;
        Trans = this.transform.parent;//get handle transform
        LeverC.transform.eulerAngles = new Vector3(Trans.eulerAngles.x - 90, Trans.eulerAngles.y - 90, Trans.eulerAngles.z - 90);

        Glue.transform.parent.parent = Hinge.transform;//set mesh parent to hinge
        Glue.transform.parent = LeverC.transform.parent;//set glue parent to Interactions

        Leak = true;
    }
}
