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
    private int playerOneActive = 0;
    [Tooltip("Fill this list with all starting units for Player 2 that are placed in the scene. Note that this list reflects the unit play order.")]
    [SerializeField] private List<PlayerUnit> playerTwoUnits;
    private int playerTwoActive = -1;
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

    void Start()
    {
        for(int i = 0; i < playerOneUnits.Count; i++)
        {
            playerOneUnits[i].SetID(i);
        }

        for(int i = 0; i < playerTwoUnits.Count; i++)
        {           
            playerTwoUnits[i].SetID(playerOneUnits.Count + i);
        }

    }

    void FixedUpdate()
    {
        if (GameManager.RoundActive())
        {

            switch (TurnManager.GetCurrentPlayer())
            {
                case PLAYER1:
                    playerOneUnits[playerOneActive].UnitMove();
                    playerOneUnits[playerOneActive].UnitLookRotation();
                    playerOneUnits[playerOneActive].UnitAimWeapon();

                    if (PlayerInputManager.JumpButtonPressed)
                    {
                        playerOneUnits[playerOneActive].UnitJump();
                        PlayerInputManager.JumpButtonPressed = false;
                    }

                    if (PlayerInputManager.FireButtonPressed)
                    {
                        playerOneUnits[playerOneActive].UnitFireProjectile();
                        PlayerInputManager.FireButtonPressed = false;
                    }

                    break;

                case PLAYER2:
                    playerTwoUnits[playerTwoActive].UnitMove();
                    playerTwoUnits[playerTwoActive].UnitLookRotation();
                    playerTwoUnits[playerTwoActive].UnitAimWeapon();

                    if (PlayerInputManager.JumpButtonPressed)
                    {
                        playerTwoUnits[playerTwoActive].UnitJump();
                        PlayerInputManager.JumpButtonPressed = false;
                    }

                    if (PlayerInputManager.FireButtonPressed)
                    {
                        playerTwoUnits[playerTwoActive].UnitFireProjectile();
                        PlayerInputManager.FireButtonPressed = false;
                    }

                    break;
            }

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
                return Instance.playerOneActive;

            case PLAYER2:
                return Instance.playerTwoActive;

            default:
                return 0;
        }

    }

    public static int GetUnitCount(int player)
    {

        if (player == PLAYER1)
        {
            return Instance.playerOneUnits.Count;
        }
        else if( player == PLAYER2)
        {
            return Instance.playerTwoUnits.Count;
        }

        return 0; 
    }

    public static void UnitDeath(int unitID)
    {

        for(int i = 0; i < Instance.playerOneUnits.Count; i++)
        {

            if(Instance.playerOneUnits[i].GetID() == unitID)
            {
                Instance.playerOneUnits[i].UnitDeath();
                Instance.playerOneUnits.RemoveAt(i);
                CameraManager.RemoveCamera(PLAYER1, i);
            }

        }

        for(int i = 0; i < Instance.playerTwoUnits.Count; i++)
        {

            if(Instance.playerTwoUnits[i].GetID() == unitID)
            {
                Instance.playerTwoUnits[i].UnitDeath();
                Instance.playerTwoUnits.RemoveAt(i);
                CameraManager.RemoveCamera(PLAYER2, i);
            }

        }

        GameManager.UpdateUnitCount();
    }


    public static void NewTurn()
    {

        switch (TurnManager.GetCurrentPlayer())
        {
            case 1:

                if(Instance.playerOneActive < Instance.playerOneUnits.Count-1)
                {
                    Instance.playerOneActive++;
                }
                else
                {
                    Instance.playerOneActive = 0;
                }
               
                break;

            case 2:

                if (Instance.playerTwoActive < Instance.playerTwoUnits.Count-1)
                {
                    Instance.playerTwoActive++;
                }
                else
                {
                    Instance.playerTwoActive = 0;
                }

                break;
        }

    }

}
