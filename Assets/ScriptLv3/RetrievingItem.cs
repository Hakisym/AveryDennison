using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrievingItem : MonoBehaviour
{
    private Vector3 StartPosition;
    private Quaternion StartRotation;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void RecordStartingPosition()
    {
        StartPosition = transform.position;
        StartRotation = transform.rotation;
    }

    public void SnappingPositionBackwards()
    {
        transform.position = StartPosition;
        transform.rotation = StartRotation;
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true ;
    }
}
