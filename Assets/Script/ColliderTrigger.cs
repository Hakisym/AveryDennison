using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public static ColliderTrigger instance;
    public GameObject Clip;
    public GameObject Case;
    public GameObject Hose;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "jdj")
        {
            Debug.Log("Collide with floor");
            Clip.transform.position = new Vector3(23.8855f, 1.28929996f, -4.29629993f);
            Clip.transform.rotation = Quaternion.Euler(0, 0, 0);
            Clip.GetComponent<Rigidbody>().isKinematic = true;
            foreach (var item in Case.GetComponentsInChildren<MeshRenderer>())
            {
                item.enabled = false;
            }
        }
        if (collision.gameObject.name == "GrabHose")
        {
            Debug.Log("Collide with floor");
            HoseCollide();
        }
    }

    public void HoseCollide()
    {
        Hose.transform.position = new Vector3(23.4559364f, 1.43595529f, -4.36395168f);
        Hose.transform.rotation = Quaternion.Euler(0, 0, 0);
        Hose.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void LerpPosition()
    {
        Hose.transform.position = Vector3.Lerp(Hose.transform.position, new Vector3(23.2652588f, 1.01317358f, -3.81183529f), Time.deltaTime);
    }

    
}
