using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeControllerLV3 : MonoBehaviour
{
    public static SmokeControllerLV3 instance;
    public ParticleSystem ps;
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
                if (hit.collider.gameObject.name == "Mabu" && i <= 100 && (Time.time - time > 0.03))
                {
                    i++;
                    time = Time.time;
                }
                if (i == 101)
                {
                    i++;
                    GameManagerLv3.instance.Fire.Stop();
                }

            }
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
