using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow Properties")]
    [Tooltip("Target the camera should follow")]
    [SerializeField] Transform targetTransform;
    [SerializeField] Transform aimTarget;
    [Tooltip("Tracking delay applied to camera. 0 is no delay.")]
    [SerializeField] private float smoothValue = 0.3f;
    [SerializeField] float rotationSpeed = 30f;

    [SerializeField] Vector3 camOffset;
    Vector3 currentVelocity = Vector3.zero;
    Vector3 targetPosition;
    Quaternion desiredRotation;

    private void Start()
    {
        transform.position = targetTransform.position + camOffset;
    }

    private void LateUpdate()
    {
        //UpdatePosition();
        //desiredRotation = Quaternion.LookRotation(aimTarget.position - transform.position);        
        transform.LookAt(aimTarget);
    }

    private void Update()
    {
        UpdatePosition();
        //transform.LookAt(aimTarget);
        //transform.LookAt(aimTarget);
        //desiredRotation = Quaternion.LookRotation(aimTarget.position - transform.position);

    }

    public void UpdatePosition()
    {
        targetPosition = targetTransform.position - targetTransform.forward * -camOffset.z;
        targetPosition.y = targetTransform.position.y + camOffset.y;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothValue);
    }

}

