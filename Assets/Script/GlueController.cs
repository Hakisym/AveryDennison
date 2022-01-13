using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using BNG;

public class GlueController : MonoBehaviour
{
    public static GlueController instance;
    public GameObject Pillow;
    public Animator animator;
    public GameObject Interaction;
    public MeshRenderer[] meshRenderers;
    public Color newColor;


    private void Start()
    {
        instance = this;
    }
    public void SecurePillow()
    {
        Pillow.transform.GetChild(0).GetComponent<HighlightEffect>().enabled = true;
        Pillow.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void SnapPhase(int i)
    {
        Pillow.transform.GetChild(i+3).gameObject.SetActive(false);
        meshRenderers[i - 1].material.color = newColor;
        if (i < 4)
        {
            Pillow.transform.GetChild(i+4).gameObject.SetActive(true);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ClothCol")
        {
            Debug.Log("Collide with Cloth");
            transform.GetChild(0).parent = Interaction.transform;
            animator.SetTrigger("Absorb");
            other.gameObject.SetActive(false);
            GetComponent<HighlightEffect>().enabled = false;
            StartCoroutine(SetGrabCloth());
            AudioMain.instance.EventPlayClip(30, false);
        }
    }

    IEnumerator SetGrabCloth()
    {
        yield return new WaitForSeconds(10);
        ClothDIsappear.instance.SetGrabbable();
    }
}
