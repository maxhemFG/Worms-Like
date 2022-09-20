using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    private PlayerMovement unitMovement;

    private void Start()
    {
        unitMovement = GetComponent<PlayerMovement>();
    }
    public void UnitMove()
    {
        unitMovement.Move();
    }

}
