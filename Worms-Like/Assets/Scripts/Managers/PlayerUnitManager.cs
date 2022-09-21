using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitManager : MonoBehaviour
{
    private const int PLAYER1 = 1;
    private const int PLAYER2 = 2;
    public static PlayerUnitManager Instance;
     
    [Header("Player Units")]
    [Tooltip("Fill this list with all starting units for Player 1 that are placed in the scene. Note that this list reflects the unit play order.")]
    [SerializeField] private List<PlayerUnit> playerOneUnits;
    private static int playerOneActive = 0;
    [Tooltip("Fill this list with all starting units for Player 2 that are placed in the scene. Note that this list reflects the unit play order.")]
    [SerializeField] private List<PlayerUnit> playerTwoUnits;
    private static int playerTwoActive = -1;
    private static int currentPlayerCount = 2;

    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    void FixedUpdate()
    {      

        switch (TurnManager.GetCurrentPlayer())
        {
            case PLAYER1:
                playerOneUnits[playerOneActive].UnitMove();

                if (PlayerInputManager.JumpButtonPressed)
                {
                    playerOneUnits[playerOneActive].UnitJump();
                    PlayerInputManager.JumpButtonPressed = false;
                }

                break;

            case PLAYER2:
                playerTwoUnits[playerTwoActive].UnitMove();

                if (PlayerInputManager.JumpButtonPressed)
                {
                    playerTwoUnits[playerTwoActive].UnitJump();
                    PlayerInputManager.JumpButtonPressed = false;
                }

                break;
        }
        
    }

    public static int GetPlayerCount()
    {
        return currentPlayerCount;
    }

    public static int GetActiveUnit()
    {
        switch (TurnManager.GetCurrentPlayer())
        {
            case PLAYER1:
                return playerOneActive;

            case PLAYER2:
                return playerTwoActive;

            default:
                return 0;
        }
    }

    public static void NewTurn()
    {

        switch (TurnManager.GetCurrentPlayer())
        {
            case 1:

                if(playerOneActive < Instance.playerOneUnits.Count-1)
                {
                    playerOneActive++;
                }
                else
                {
                    playerOneActive = 0;
                }
               
                break;

            case 2:

                if (playerTwoActive < Instance.playerTwoUnits.Count-1)
                {
                    playerTwoActive++;
                }
                else
                {
                    playerTwoActive = 0;
                }

                break;
        }

    }

}
