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
    public ParticleSystem Spark;
    public Text text;
    public GameObject Mesh;
    public GameObject Emmiter;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isPlaying)
        {
            if (Physics.Raycast(Hose.transform.position, Emmiter.transform.forward, out hit, 1f, 1 << 0, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.gameObject.name == "FireCollider")
                {
                    if (time < 10)
                    {
                        time += Time.deltaTime;
                        time.ToString("F2");
                        text.text = string.Format("{0:F2}S", time);
                        GameManager.instance.FireTong.enabled = false;
                    }
                    else//If reach 10 seconds disable UI and particles 
                    {
                        time = 10;
                        text.text = 10+"S";
                        text.transform.parent.gameObject.SetActive(false);
                        UnHold();
                        GetPosition.instance.Leak = false;
                        GetPosition.instance.Retreat = true;
                        GameManager.instance.YellowCap.enabled = true;
                        GameManager.instance.YellowCap.GetComponent<HighlightPlus.HighlightEffect>().enabled = true;
                        AudioMain.instance.EventPlayClip(35, false);

                        //callback of ArrowManager
                        ArrowManager.Instance.OpenArrow("OutsideRight");
                    }
                    
                }
                
                if (hit.collider.gameObject.name == "FireCollider_Center")
                {
                    //Audio
                    PlaySpark();
                    Debug.Log("Don't spray at the center!");
                }
            }
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
            Hose.transform.GetChild(0).localRotation = Quaternion.Lerp(Quaternion.Euler(0, -21.608f,90), Quaternion.Euler(0, -21.608f, 0), startTime / 3);
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
            Mesh.transform.GetChild(0).localRotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), startTime_2 / 3);
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
        Vector3 position = Mesh.transform.GetChild(1).localPosition;
        SafeRunning = true;
        while (startTime_3 < 2)
        {
            Mesh.transform.GetChild(1).localPosition = Vector3.Lerp(position, new Vector3(position.x,position.y,position.z-0.3f), startTime_3 / 2);
            startTime_3 += Time.deltaTime;
            yield return null;
        }
        Mesh.transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
        SafeRunning = false;
        SafeRun = true;
    }
    public void PlaySpark()
    {
        StartCoroutine(Sparking());
    }

    IEnumerator Sparking()
    {
        Spark.Play();
        yield return new WaitForSeconds(2);
        Spark.Stop();
    }

}
