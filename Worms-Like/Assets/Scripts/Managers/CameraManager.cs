using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [Header("Camera GameObjects")]
    [Tooltip("Fill this list with the focus camera on each player unit. WARNING: Make sure that the element order corresponds to the play order for the corresponding player.")]
    [SerializeField] private List<CinemachineVirtualCamera> focusCamPlayer1;
    [Tooltip("Fill this list with the focus camera on each player unit. WARNING: Make sure that the element order corresponds to the play order for the corresponding player.")]
    [SerializeField] private List<CinemachineVirtualCamera> focusCamPlayer2;
    private int previousUnit = 0;
    private bool cameraSwapped = true;

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

        for(int i = 1; i < focusCamPlayer1.Count; i++)
        {
            focusCamPlayer1[i].enabled = false;
        }

        for (int i = 0; i < focusCamPlayer2.Count; i++){
            focusCamPlayer2[i].enabled = false;
        }

    }
    private void LateUpdate()
    {

        if (TurnManager.InTransition())
        {
            cameraSwapped = false;
            previousUnit = PlayerUnitManager.GetActiveUnit();
        } else if (!TurnManager.InTransition() && !cameraSwapped)
        {
            SwapCamera();
            cameraSwapped = true;
        }
       
    }

    private void SwapCamera()
    {

        switch (TurnManager.GetCurrentPlayer())
        {
            case 1:              
                focusCamPlayer1[PlayerUnitManager.GetActiveUnit()].enabled = true;
                focusCamPlayer2[previousUnit].enabled = false;
                break;

            case 2:
                focusCamPlayer2[PlayerUnitManager.GetActiveUnit()].enabled = true;
                focusCamPlayer1[previousUnit].enabled = false;
                break;
        }

    }
}
