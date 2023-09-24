using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;

    private PanelController panelController;

    private void Awake()
    {
        endManager = this;
    }

    void Start()
    {

    }

    public void WinGame()
    {
        // activate the panel
        // unlock next level
        // score
        panelController.ActivateWin();
    }

    public void LoseGame()
    {
        panelController.ActivateLose();
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }
}
