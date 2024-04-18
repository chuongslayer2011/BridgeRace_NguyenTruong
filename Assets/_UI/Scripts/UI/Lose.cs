using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : UICanvas
{
    public void RestartLevel()
    {
        GameplayManager.instance.ResumeGame();
        GameplayManager.instance.RestartGame();
        UIController.instance.InGame();
    }
}
