using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Obi;

public class FIreExtinguisher : MonoBehaviour
{
    public Rigidbody Handle;
    public Rigidbody Hose;
    public ParticleSystem ps;
    public Text text;
    internal int i = 0;
    RaycastHit hit;
    float time;
    float startTime;
    float startTime_2;
    float startTime_3;
    bool ValRunning;
    bool ValRun;
    bool SwtRunning;
    bool SwtRun;
    bool SafeRunning;
    bool SafeRun;
    // Start is called before the first frame update
    void Start()
    {
        Handle.isKinematic = true;
        Hose.isKinematic = true;
        //Handle.isKinematic = false;
        //Hose.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isPlaying)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, 1 << 0, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.gameObject.name == "jh" && i <= 100)//&& (Time.time - time > 0.1)
                {
                    i++;
                    time = Time.time;

                    text.text = i + "%";
                }
                if (hit.collider.gameObject.name == "CenterCol")
                {
                    //Audio
                    Debug.Log("Don't spray at the center!");
                }
            }
        }


        if (i == 100)
        {
            i = 0;
        }
    }
    public void Hold()
    {
        if (ValRun&&SwtRun&&SafeRun)
        {
            ps.Play();
        }
        

    }
    public void UnHold()
    {
        ps.Stop();
    }

    public void Valve()
    {
        if (!ValRunning)
        {
            StartCoroutine(TurnValve());
        }
    }

    IEnumerator TurnValve()
    {
        ValRunning = true;
        while (startTime < 3)
        {
            Hose.transform.GetChild(0).rotation = Quaternion.Lerp(Quaternion.Euler(0, -21.608f,0), Quaternion.Euler(0, -21.608f, 90), startTime / 3);
            startTime += Time.deltaTime;
            yield return null;
        }
        ValRunning = false;
        ValRun = true;
    }

    public void Switch()
    {
        if (!SwtRunning)
        {
            StartCoroutine(TurnSwitch());
        }
    }

    IEnumerator TurnSwitch()
    {
        SwtRunning = true;
        while (startTime_2 < 3)
        {
            Hose.transform.parent.GetChild(1).rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), startTime_2 / 3);
            startTime_2 += Time.deltaTime;
            yield return null;
        }
        SwtRunning = false;
        SwtRun = true;
    }
    public void Safety()
    {
        if (!SafeRunning)
        {
            StartCoroutine(TurnSafety());
        }
    }

    IEnumerator TurnSafety()
    {
        Vector3 position = Hose.transform.parent.GetChild(2).position;
        SafeRunning = true;
        while (startTime_3 < 2)
        {
            Hose.transform.parent.GetChild(2).position = Vector3.Lerp(position, new Vector3(position.x,position.y,position.z-0.3f), startTime_3 / 2);
            startTime_3 += Time.deltaTime;
            yield return null;
        }
        Hose.transform.parent.GetChild(2).GetComponent<Rigidbody>().isKinematic = false;
        SafeRunning = false;
        SafeRun = true;
    }
}
