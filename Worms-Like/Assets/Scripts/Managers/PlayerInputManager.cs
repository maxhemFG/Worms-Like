using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;

    public static Vector2 movement;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!TurnManager.InTransition())
        {
            movement = context.ReadValue<Vector2>();
        }
        else
        {
            movement = Vector2.zero;
        }
        
    }

}
