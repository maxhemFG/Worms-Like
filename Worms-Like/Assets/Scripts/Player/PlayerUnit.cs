using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    private PlayerState unitState;
    private PlayerMovement unitMovement;

    private void Start()
    {
        unitState = GetComponent<PlayerState>();
        unitMovement = GetComponent<PlayerMovement>();
    }

    public void UnitMove()
    {
        unitMovement.Move();
    }

    public void UnitJump()
    {

        if (unitState.IsGrounded())
        {
            unitMovement.Jump();
        }
        else
        {
            Debug.Log("Not grounded!");
        }
        
    }

}
