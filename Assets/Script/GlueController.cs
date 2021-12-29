using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using BNG;

public class GlueController : MonoBehaviour
{
    public GameObject Pillow;
    public Animator animator;
    public GameObject Interaction;
    public MeshRenderer[] meshRenderers;
    public Color newColor;

    
    public void SecurePillow()
    {
        Pillow.SetActive(true);
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
            transform.GetChild(0).parent = Interaction.transform;
            Debug.Log(other.gameObject.name);
            animator.SetTrigger("Absorb");
            StartCoroutine(DisableHighlight());
        }
    }

    IEnumerator DisableHighlight()
    {
        yield return new WaitForSeconds(10);
        GetComponent<HighlightEffect>().enabled = false;
        ClothDIsappear.instance.SetGrabbable();
    }
}
