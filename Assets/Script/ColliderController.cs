using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public GameObject[] Levels;
    public static ColliderController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelLoad(int i)
    {
        Levels[i].SetActive(true);
    }

    public void LevelUnload(int i)
    {
        Levels[i].SetActive(false);
    }
}