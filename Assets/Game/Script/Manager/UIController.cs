using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] UICanvas inGameUI;

    [SerializeField] UICanvas mainMenuUI;
    [SerializeField] UICanvas winUI;
    [SerializeField] UICanvas loseUI;
    [SerializeField] UICanvas pauseUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        CloseAll();
        mainMenuUI.Open();
        Time.timeScale = 0f;
    }

    public void InGame()
    {
        CloseAll();
        inGameUI.Open();
        
    }

    public void Win()
    {
        CloseAll();
        winUI.Open();
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        CloseAll();
        loseUI.Open();
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        CloseAll();
        pauseUI.Open();
        
    }

    public void CloseAll()
    {
        mainMenuUI.Close();
        winUI.Close();
        loseUI.Close();
        pauseUI.Close();
        inGameUI.Close();
    }
}
