using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitManager : MonoBehaviour
{
    public static PlayerUnitManager instance;

    private static int currentPlayerCount = 2;
    
    [SerializeField] private List<PlayerUnit> playerOneUnits;
    private static int playerOneActive = 0;
    [SerializeField] private List<PlayerUnit> playerTwoUnits;
    private static int playerTwoActive = -1;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void FixedUpdate()
    {

        switch (TurnManager.GetCurrentPlayer())
        {
            case 1:
                playerOneUnits[playerOneActive].UnitMove();
                break;

            case 2:
                playerTwoUnits[playerTwoActive].UnitMove();
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

                if(playerOneActive < instance.playerOneUnits.Count-1)
                {
                    playerOneActive++;
                }
                else
                {
                    playerOneActive = 0;
                }
               
                break;

            case 2:

                if (playerTwoActive < instance.playerTwoUnits.Count-1)
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
