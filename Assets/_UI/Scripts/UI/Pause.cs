using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : UICanvas
{
    public void Resume()
    {
        GameplayManager.instance.ResumeGame();
        UIController.instance.InGame();
    }

    public void Restart()
    {
        GameplayManager.instance.ResumeGame();
        GameplayManager.instance.RestartGame();
        UIController.instance.InGame();
    }

    public void MainMenu()
    {
        GameplayManager.instance.ResumeGame();
        UIController.instance.OpenMainMenu();
    }
}
