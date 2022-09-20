using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitManager : MonoBehaviour
{
    private const int PLAYER1 = 1;
    private const int PLAYER2 = 2;
    public static PlayerUnitManager Instance;
    private static int currentPlayerCount = 2;   
    [SerializeField] private List<PlayerUnit> playerOneUnits;
    private static int playerOneActive = 0;
    [SerializeField] private List<PlayerUnit> playerTwoUnits;
    private static int playerTwoActive = -1;

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
