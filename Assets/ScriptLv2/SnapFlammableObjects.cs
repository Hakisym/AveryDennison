using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapFlammableObjects : MonoBehaviour
{
    private int Count;
    private SnapZone snapZone;

    private void Awake()
    {
        snapZone = GetComponentInChildren<SnapZone>();
    }

    public void HandleSnapFlammable()
    {
        snapZone.HeldItem.gameObject.SetActive(false);
        snapZone.ReleaseAll();
        Count++;
        gameObject.SetActive(Count < 3);
    }
}
