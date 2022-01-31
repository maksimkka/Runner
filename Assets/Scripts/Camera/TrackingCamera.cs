using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 offset;

    private void Start()
    {
        offset = target.InverseTransformPoint(transform.position);
    }

    private void LateUpdate()
    {
        var currentPosition = target.TransformPoint(offset);
        transform.position = currentPosition;

        transform.LookAt(target);
    }
}
