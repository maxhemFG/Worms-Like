using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("Ground Check Attributes")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckOffset;
    private Rigidbody unitRigidbody;
    private bool isGrounded = true;
    private float unitHeight;

    [Header("PlayerState Dependent Physics")]
    [Tooltip("The maximum multiplier that is applied to the player down vector while in air.")]
    [SerializeField] private float gravityInAir = 3f;
    [Tooltip("The time it takes to reach the maximum multiplier.")]
    [SerializeField] private float gravityScaleDuration = 0.5f;
    private float timerGravityScale = 0f;
    private float gravityScaler = 0f;
    private float gravityScaled = 0f;

    private void Start()
    {
        unitHeight = GetComponent<CapsuleCollider>().height;
        unitRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        ApplyGravity();
    }

    void CheckGrounded()
    {

        if (Physics.Raycast(gameObject.transform.localPosition, -transform.up, out RaycastHit hit, unitHeight / 2 + groundCheckOffset, groundLayer))
        {
            Debug.DrawRay(transform.position, -transform.up, Color.red, .2f);
            isGrounded = true;
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up, Color.yellow, .2f);
            isGrounded = false;
        }

    }
    public bool IsGrounded()
    {
        return isGrounded;
    }

    private void ApplyGravity()
    {
        
        if (!isGrounded)
        {
            timerGravityScale += Time.fixedDeltaTime;

            if(timerGravityScale < gravityScaleDuration)
            {
                gravityScaler = Mathf.Lerp(gravityScaler, gravityInAir, timerGravityScale);
            }
           
            gravityScaled = Physics.gravity.y * gravityScaler;
            unitRigidbody.AddForce(-transform.up * -gravityScaled, ForceMode.Acceleration);
        }
        else
        {
            gravityScaler = 0f;
            timerGravityScale = 0f;
        }

    }

}
