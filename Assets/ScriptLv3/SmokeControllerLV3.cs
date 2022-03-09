using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeControllerLV3 : MonoBehaviour
{
    public static SmokeControllerLV3 instance;
    public ParticleSystem ps;
    public GameObject ExitButton;
    internal int i = 0;
    RaycastHit hit;
    float time;
    private bool IsPinRemoved;
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
                    StopFireandPlayAudio();
                }

            }
        }


        
    }

    public void Hold()
    {
        if(IsPinRemoved)
        ps.Play();
    }
    public void UnHold()
    {
        ps.Stop();
    }

    void StopFireandPlayAudio() {

        GameManagerLv3.instance.Fire.Stop();
        //Also disable the UI arrow 
        GameObject.Find("ArrowsForFlammableObject").SetActive(false);
        //Play Audio Instance
        AudioMain.instance.PlayDelayClip(15,16);
        //Find the Exit Button
        ExitButton.SetActive(true);
    }

    public void CheckIfPinRemoved()
    {
        IsPinRemoved = true;
    }
}
