using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;

public class ColliderTrigger : MonoBehaviour
{
    public static ColliderTrigger instance;
    public GameObject Clip;
    public GameObject Case;
    public GameObject Hose;
    public HighlightEffect BarrelHandle;
    float startTime;
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
            if (!GameManager.instance.ReleaseHose)
            {
                AudioMain.instance.EventPlayClip(12, false);
            }
            
        }
        if (collision.gameObject.name == "GrabHose")
        {
            Debug.Log("Collide with floor");
            HoseCollide();
            if (!GameManager.instance.ReleaseHose)
            {
                AudioMain.instance.EventPlayClip(13, false);
            }
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
        StartCoroutine(LerpHose());
    }

    IEnumerator LerpHose()
    {
        while (startTime < 3)
        {
            Hose.transform.position = Vector3.Lerp(new Vector3(23.4559364f, 1.43595529f, -4.36395168f), new Vector3(23.2652588f, 1.01317358f, -3.81183529f), startTime / 3);
            startTime += Time.deltaTime;
            yield return null;
        }
        HoseCollide();
    }


}
