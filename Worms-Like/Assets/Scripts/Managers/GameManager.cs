using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private const int PLAYER1 = 1;
    private const int PLAYER2 = 2;
    int playerOneUnitCount = 0;
    int playerTwoUnitCount = 0;
    bool gameOver = false;
    int victoriousPlayer = 0;

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

    private void Start()
    {
        UpdateUnitCount();
    }

    private void Update()
    {
        if (gameOver)
        {
            Cursor.lockState = CursorLockMode.None;

            if (victoriousPlayer == PLAYER1)
            {
                SceneManager.LoadScene("WinSceneP1");
            }
            else if (victoriousPlayer == PLAYER2)
            {
                SceneManager.LoadScene("WinSceneP2");
            }
        }
        
    }

    public static void UpdateUnitCount()
    {
        Instance.playerOneUnitCount = PlayerUnitManager.GetUnitCount(PLAYER1);
        Instance.playerTwoUnitCount = PlayerUnitManager.GetUnitCount(PLAYER2);

        if(Instance.playerOneUnitCount <= 0)
        {
            Instance.gameOver = true;
            Instance.victoriousPlayer = PLAYER2;
        } else if(Instance.playerTwoUnitCount <= 0)
        {
            Instance.gameOver = true;
            Instance.victoriousPlayer = PLAYER1;
        }
    }

    public static bool RoundActive() //Make check when running UnitManager and CameraManager to avoid Null Reference- OR MAKE IT IN TURNMANAGER ONLY UPDATE SHIT IF NOT GAMEOVER... ONLY CONTROL UNITS AND TURN WHEN ACTIVE
    {
        return !Instance.gameOver;
    }
}
