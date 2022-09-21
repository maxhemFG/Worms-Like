using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody unitRigidBody;
    [Header("Movement Attributes")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;

    Vector3 moveDirection = Vector3.zero;
    Vector3 moveForce = Vector3.zero;

    private void Start()
    {
        unitRigidBody = GetComponent<Rigidbody>();
    }

    public void Move() //Look at ground check!!! should be sphere not raycast. Cant handle edges with raycast!!!
    {
        //Debug.Log(gameObject.transform.name);
        moveDirection = new Vector3(PlayerInputManager.MovementInput.x, 0, PlayerInputManager.MovementInput.y);
        moveDirection.Normalize();
        moveForce = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.z * moveSpeed);

        unitRigidBody.AddForce(moveForce, ForceMode.VelocityChange);      
        unitRigidBody.velocity = Vector3.ClampMagnitude(unitRigidBody.velocity, moveSpeed);       
    }

    public void Jump()
    {
        //Debug.Log(gameObject.transform.name + "Jumping");
        unitRigidBody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
    }
}
