using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    [Header("Turn Attributes")]
    [Tooltip("The duration of a turn in seconds.")]
    [SerializeField] private float turnDuration = 45f;
    private float timerTurnDuration = 0f;
    [SerializeField] private float turnTransitionDelay = 1f;
    private float timerTurnTransition = 0f;

    private static int currentPlayer = 1;
    private List<int> alivePlayers;

    private bool turnTransition = false;

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

        alivePlayers = new List<int>();
    }

    private void Start()
    {
        for(int i = 0; i < PlayerUnitManager.GetPlayerCount(); i++)
        {
            alivePlayers.Add(i + 1);
        }

    }

    void Update()
    {
        timerTurnDuration += Time.deltaTime;

        if(timerTurnDuration >= turnDuration)
        {
            turnTransition = true;
            timerTurnTransition += Time.deltaTime;

            if(timerTurnTransition >= turnTransitionDelay)
            {
                ChangeTurn();
                timerTurnDuration = 0f;
                timerTurnTransition = 0f;
            }
            
        } //else if(playerUnitManger.GetActiveUnit.isDead) ChangeTurn()

    }

    void ChangeTurn()
    {
        if(currentPlayer < alivePlayers.Count)
        {
            currentPlayer++;
        }
        else
        {
            currentPlayer = alivePlayers[0];
        }

        PlayerUnitManager.NewTurn();
        turnTransition = false;
        //Debug.Log("Current Player Turn: " + currentPlayer);
    }

    public static int GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public static bool InTransition()
    {
        return Instance.turnTransition;
    }
}
