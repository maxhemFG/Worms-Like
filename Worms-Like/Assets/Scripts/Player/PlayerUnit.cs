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

        if (unitState.IsGrounded())
        {
            unitMovement.Move();
        }
           
    }

    public void UnitLookRotation()
    {
        unitMovement.LookRotation();
    }

    public void UnitJump()
    {

        if (unitState.IsGrounded())
        {
            unitMovement.Jump();
        }
        else
        {
            //Debug.Log("Not grounded!");
        }
        
    }

}
