using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIdle : MonoBehaviour
{
    [SerializeField] private float yOffset = 8;
    [SerializeField] private float speed = 10;
    private RectTransform thisTransform;
    private Vector3 startPosition;
    private Vector3 lowerBound;
    private Vector3 upperBound;
    bool dropping = true;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<RectTransform>();
        startPosition = thisTransform.localPosition;
        upperBound = new Vector3(startPosition.x, startPosition.y + yOffset, startPosition.z);
        lowerBound = new Vector3(startPosition.x, startPosition.y - yOffset, startPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dropping)
        {
            GoUp();

        }
        else if(dropping)
        {
            GoDown();
        }
    }

    private void GoUp()
    {   
        if (thisTransform.localPosition.y < upperBound.y)
        {
            thisTransform.localPosition = Vector3.MoveTowards(thisTransform.localPosition, upperBound, Time.deltaTime * speed);
        }
        else
        {
            dropping = true;
        }
    }
    
    
    private void GoDown()
    {
        if (thisTransform.localPosition.y > lowerBound.y)
        {
            thisTransform.localPosition = Vector3.MoveTowards(thisTransform.localPosition, lowerBound, Time.deltaTime*speed);
        }
        else
        {
            dropping = false;
        }
    }
}
