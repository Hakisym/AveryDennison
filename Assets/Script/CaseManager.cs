using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{



    public GameObject Cap;
    public GameObject Cdoor;
    float startTime;
    float startTime_2;
    bool SwtRunning;
    bool SwtRun;
    bool DoorOpenning;
    bool DoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        while (startTime < 2)
        {
            Cap.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, -135), startTime / 2);
            startTime += Time.deltaTime;
            yield return null;
        }
        SwtRunning = false;
        SwtRun = true;
    }

    public void Door()
    {
        if (!DoorOpenning)
        {
            StartCoroutine(TurnDoor());
        }
    }

    IEnumerator TurnDoor()
    {
        DoorOpenning = true;
        while (startTime_2 < 3)
        {
            Cdoor.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 105, 0), startTime_2 / 3);
            startTime_2 += Time.deltaTime;
            yield return null;
        }
        DoorOpenning = false;
        DoorOpen = true;
    }
}
