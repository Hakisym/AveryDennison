using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public GameObject Clip;
    public GameObject Case;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Clip")
        {
            Debug.Log("Collide with floor");
            Clip.transform.position = new Vector3(23.8780994f, 1.26820004f, -4.29580021f);
            Clip.transform.rotation = Quaternion.Euler(0, 0, 0);
            Clip.GetComponent<Rigidbody>().isKinematic = true;
            foreach (var item in Case.GetComponentsInChildren<MeshRenderer>())
            {
                item.enabled = false;
            }
        }
    }
}
