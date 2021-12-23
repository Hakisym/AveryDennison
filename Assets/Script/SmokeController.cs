using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

public class SmokeController : MonoBehaviour
{
    public ParticleSystem ps;
    public Text text;
    private int i = 0;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isPlaying)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, 1 << 0, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.gameObject.name == "jh")
                {
                    StartCoroutine("Quarter");
                    hit.collider.enabled = false;
                }
            }
        }
        

        text.text = i+"/4";

        //if(i == 4)
        //{

        //}
    }

    public void Hold()
    {
        ps.Play();

    }
    public void UnHold() 
    {
        ps.Stop();
    }

    IEnumerator Quarter()
    {
        yield return new WaitForSeconds(2f);
        i++;
    }
}
