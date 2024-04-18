using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public void TapToStart()
    {
        GameplayManager.instance.ResumeGame();
        LevelManager.instance.LoadLevel(1);
        UIController.instance.InGame();
    }
}
