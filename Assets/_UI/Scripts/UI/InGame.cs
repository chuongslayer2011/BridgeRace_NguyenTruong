using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : UICanvas
{
    public void PauseGame()
    {
        GameplayManager.instance.PauseGame();
        UIController.instance.Pause();
    }
}
