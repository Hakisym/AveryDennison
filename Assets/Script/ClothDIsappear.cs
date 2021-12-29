using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using Obi;

public class ClothDIsappear : MonoBehaviour
{
    public static ClothDIsappear instance;
    public GameObject Cloth;
    public GameObject Solver;
    public GameObject SnapPoint;
    public Collider[] colliders;
    public GameObject[] gameObjects;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClothDisappear()
    {
        GameObject.Find("FrictionCloth(Clone)").SetActive(false);
        Cloth.transform.position = SnapPoint.transform.position;
        Cloth.SetActive(true);
    }

    public void SetGrabbable()
    {
        Cloth.GetComponent<ObiParticleAttachment>().enabled = true;
        Cloth.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);

        foreach(var item in colliders)
        {
            item.enabled = true;
        }
        foreach(var item in gameObjects)
        {
            item.SetActive(true);
        }
        animator.transform.parent.gameObject.SetActive(true);

    }
}
