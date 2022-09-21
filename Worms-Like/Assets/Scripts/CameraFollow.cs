using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow Properties")]
    [Tooltip("Target the camera should follow")]
    [SerializeField] Transform targetTransform;
    [Tooltip("Tracking delay applied to camera. 0 is no delay.")]
    [SerializeField] private float smoothValue = 0.3f;

    [SerializeField] Vector3 camOffset;
    Vector3 currentVelocity = Vector3.zero;
    Vector3 targetPosition;

    private void Start()
    {
        transform.position = targetTransform.position + camOffset;
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        targetPosition = targetTransform.position + camOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothValue);
    }

}

