using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance;
    public static Vector2 MovementInput;
    public static Vector2 LookInput;
    public static bool JumpButtonPressed;

    void Awake()
    {

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        Cursor.lockState = CursorLockMode.Locked;

    }

    public void Move(InputAction.CallbackContext context)
    {

        if (!TurnManager.InTransition())
        {
            MovementInput = context.ReadValue<Vector2>();
        }
        else
        {
            MovementInput = Vector2.zero;
        }
        
    }

    public void Look(InputAction.CallbackContext context)
    {
        if (!TurnManager.InTransition())
        {
            LookInput = context.ReadValue<Vector2>();
        }
        else
        {
            LookInput = Vector2.zero;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (!TurnManager.InTransition() && context.performed)
        {
            JumpButtonPressed = true;
        }
        else
        {
            JumpButtonPressed = false;
        }

    }

}
