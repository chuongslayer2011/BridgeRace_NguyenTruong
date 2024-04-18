using Scriptable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{   
    public static MapController instance;
    [SerializeField] private List<Stage> stages = new List<Stage>();
    [SerializeField] private Transform spawnPoint;
    private void Awake()
    {
        
        instance = this;
        
    }
    public void SpawnBrick(int index)
    {
        stages[index].GenerateWorld();
    }
    public void RespawnBrick(int index)
    {
        stages[index].RespawnBrick();
    }
    public void AddColorToStage(int index, ColorType colorType)
    {
        stages[index].AddColorToSpawn(colorType);
    }
    public void RemoveBridgeOnStage(int index, Brick brick, Vector3 pos)
    {
        stages[index].RemoveBrickOnMap(brick, pos);
    }
    public Vector3 GetBrickOnStage(int index, ColorType colorType)
    {
        return stages[index].getBrickPosition(colorType);
    }
    public bool checkBrickOnStage(int index)
    {
        return stages[index].checkBrickOnFlatForm();
    }
    public Stage GetStage(int index)
    {
        return stages[index];
    }
    public Transform GetTargetPointCurrentStage(int index)
    {
        return stages[index].GetTargetPoint();
    }
    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }
    public void ClearAllBrick()
    {
        for(int i = 0; i < stages.Count; i++)
        {
            stages[i].ClearAllBrick(); 
        }
    }
    public void RemoveColorFromStage(int index, ColorType colorType)
    {
        stages[index].RemoveColorFromBeingRespawned(colorType);
    }
}
