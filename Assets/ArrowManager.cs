using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public GameObject[] arrows;
    public static ArrowManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenArrow(string name)
    {
        foreach(var arrow in arrows)
        {
            if (arrow.name == name)
            {
                arrow.SetActive(true);
                CloseArrow(arrow);
            }
            else if (arrow.activeSelf)
            {
                arrow.SetActive(false);
            }
        }
    }

    public void OpenArrow(GameObject name)
    {
        foreach (var arrow in arrows)
        {
            if (arrow == name)
            {
                arrow.SetActive(true);
                CloseArrow(arrow);
            }
            else if (arrow.activeSelf)
            {
                arrow.SetActive(false);
            }
        }
    }

    void CloseArrow(GameObject name)
    {
        StartCoroutine(CloseArrowInTime(name));
    }


    IEnumerator CloseArrowInTime(GameObject target)
    {
        yield return new WaitForSeconds(5f);
        target.SetActive(false);
    }
}
