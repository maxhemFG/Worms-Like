using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckOffset;
    private bool isGrounded = true;
    private float unitHeight;

    private void Start()
    {
        unitHeight = GetComponent<CapsuleCollider>().height;
    }

    private void FixedUpdate()
    {
        CheckGrounded();
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

}
