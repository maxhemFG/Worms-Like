using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody unitRigidBody;
    [SerializeField] private float moveSpeed = 10f;

    Vector3 moveDirection = Vector3.zero;
    Vector3 moveForce = Vector3.zero;
    public void Move()
    {
        //Debug.Log(gameObject.transform.name);
        moveDirection = new Vector3(PlayerInputManager.movement.x, 0, PlayerInputManager.movement.y);
        moveDirection.Normalize();
        moveForce = new Vector3(moveDirection.x * moveSpeed, unitRigidBody.velocity.y, moveDirection.z * moveSpeed);

        unitRigidBody.AddForce(moveForce, ForceMode.VelocityChange);        
        unitRigidBody.velocity = Vector3.ClampMagnitude(unitRigidBody.velocity, moveSpeed);
    }
}
