using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    private PlayerState unitState;
    private PlayerMovement unitMovement;
    private PlayerWeapon unitBazooka;
    private int unitID = 0; //Set in UnitManger on start. Make SetID method from PlayerUnit.

    private void Start()
    {
        unitState = GetComponent<PlayerState>();
        unitMovement = GetComponent<PlayerMovement>();
        unitBazooka = GetComponentInChildren<PlayerWeapon>();
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

    public void UnitAimWeapon()
    {
        unitBazooka.AimWeapon();
    }

    public void UnitFireProjectile()
    {
        unitBazooka.FireProjectile(unitState.IsGrounded());
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
