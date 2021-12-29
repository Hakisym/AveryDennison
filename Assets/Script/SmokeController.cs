using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

public class SmokeController : MonoBehaviour
{
    public static SmokeController instance;
    public ParticleSystem ps;
    public Text text;
    internal int i = 0;
    RaycastHit hit;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isPlaying)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, 1 << 0, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.gameObject.name == "jh" && i<=100 )//&& (Time.time - time > 0.1)
                {
                    i++;
                    time = Time.time;
                }
                if(hit.collider.gameObject.name == "CenterCol")
                {
                    //Audio
                    Debug.Log("Don't spray at the center!");
                }
            }
        }
        
        text.text = i+"%";

        if (i == 100)
        {
            i = 0;
            GameManager.instance.Napkin();
        }

    }

    public void Hold()
    {
        ps.Play();

    }
    public void UnHold() 
    {
        ps.Stop();
    }

}
