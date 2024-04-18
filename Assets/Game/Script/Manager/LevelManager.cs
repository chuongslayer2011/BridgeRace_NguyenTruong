using Scriptable;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField]
    List<MapController> levels = new List<MapController>();
    [SerializeField]
    private List<Character> characters = new List<Character>();
    private MapController currentlevel;
    private int level;
    private void Awake()
    {

        instance = this;
    }

    public void LoadLevel(int level)
    {
        this.level = level;
        if (currentlevel != null)
        {   
            currentlevel.ClearAllBrick();
            Destroy(currentlevel.gameObject);
        }
        currentlevel = Instantiate(levels[level - 1]);
        this.Onit();
        UIController.instance.CloseAll();
    }
    public void LoadNextLevel()
    {
        if (currentlevel != null)
        {
            this.level++;
            LoadLevel(level);
        }
    }
    public void RePlayCurretLevel()
    {
        LoadLevel(level);
    }
    public void Onit()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].OnInit();
        }
    }
    public ColorType GetMostBrickCharacterOnLevel()
    {   
        characters.Sort();
        return characters[characters.Count - 1].GetColorType();
    }
    public ColorType GetSecondMostBrickCharacter()
    {
        characters.Sort();
        return characters[characters.Count - 2].GetColorType();
    }
}
