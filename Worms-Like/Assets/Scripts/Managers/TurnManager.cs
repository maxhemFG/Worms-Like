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
    [Tooltip("The delay between turns in seconds.")]
    [SerializeField] private float turnTransitionDelay = 1f;
    private float timerTurnTransition = 0f;

    private int currentPlayer = 1;
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

        if (GameManager.RoundActive())
        {
            timerTurnDuration += Time.deltaTime;

            if (timerTurnDuration >= turnDuration)
            {
                turnTransition = true;
                timerTurnTransition += Time.deltaTime;

                if (timerTurnTransition >= turnTransitionDelay)
                {
                    ChangeTurn();
                }

            }
           
        }
      
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
        timerTurnDuration = 0f;
        timerTurnTransition = 0f;
    }

    public static int GetCurrentPlayer()
    {
        return Instance.currentPlayer;
    }

    public static bool InTransition()
    {
        return Instance.turnTransition;
    }

}
