using Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    
    [SerializeField] private List<Vector3> spawnPoint;
    [SerializeField] private List<Transform> targetPoint;
    private GameObject spawnedBrick;
    [SerializeField] private Brick BrickPrefab;
    [SerializeField] private ColorData colorData;
    public List<ColorType> colorToSpawn = new List<ColorType>();
    private List<Brick> currentBrickonMap = new List<Brick>();
    private Dictionary<Vector3, bool> checkSpawned = new Dictionary<Vector3, bool>();
    private bool IsReach;
    public void RespawnBrick()
    {
        if (colorToSpawn.Count == 0)
        {
            return;
        }
        for (int i = 0; i < spawnPoint.Count; i++)
        {
            if (checkSpawned[spawnPoint[i]] == false)
            {

                Brick spawnedBrick = SimplePool.Spawn<Brick>(PoolType.Brick, spawnPoint[i], Quaternion.Euler(0, 0, 0));
                ColorType randomColor = RandomColorType();
                spawnedBrick.SetColor(randomColor);
                spawnedBrick.SetColorType(randomColor);
                currentBrickonMap.Add(spawnedBrick);
                checkSpawned[spawnPoint[i]] = true;
            }
        }
        for (int i = 0; i < currentBrickonMap.Count; i++)
        {
            ColorType randomColor = RandomColorType();
            currentBrickonMap[i].SetColor(randomColor);
            currentBrickonMap[i].SetColorType(randomColor);
        }
    }
    public void GenerateWorld()
    {
        for (int i = 0; i < spawnPoint.Count; i++)
        {
            Brick spawnedBrick = SimplePool.Spawn<Brick>(PoolType.Brick, spawnPoint[i], Quaternion.Euler(0, 0, 0));
            ColorType randomColor = RandomColorType();
            spawnedBrick.SetColor(randomColor);
            spawnedBrick.SetColorType(randomColor);
            currentBrickonMap.Add(spawnedBrick);
            checkSpawned.Add(spawnPoint[i], true);
        }
        InvokeRepeating(nameof(RespawnBrick), 0f, 5f);
    }
    public void RemoveBrickOnMap(Brick brick, Vector3 pos)
    {
        checkSpawned[pos] = false;
        currentBrickonMap.Remove(brick);

    }
    public void AddColorToSpawn(ColorType colorType)
    {
        colorToSpawn.Add(colorType);
    }
    public ColorType RandomColorType()
    {   
        if(colorToSpawn != null)
        {
            int random = UnityEngine.Random.Range(0, colorToSpawn.Count);
            return colorToSpawn[random];
        }
        return ColorType.None;
    }
    public Vector3 getBrickPosition(ColorType colorType)
    {
        for (int i = 0; i < currentBrickonMap.Count; i++)
        {
            if (currentBrickonMap[i].GetColorType() == (int)colorType)
            {
                return currentBrickonMap[i].transform.position;
            }
        }
        return Vector3.zero;
    }
    public bool checkBrickOnFlatForm()
    {
        return currentBrickonMap.Count > 0;
    }
    public void SetIsReach(bool isReach)
    {
        this.IsReach = isReach;
    }
    public bool CheckIsReach()
    {
        return this.IsReach;
    }
    public Transform GetTargetPoint()
    {
        int random = UnityEngine.Random.Range(0, targetPoint.Count);
        return targetPoint[random];
    }
    public void ClearAllBrick()
    {
        int amount = currentBrickonMap.Count;
        for(int i = 0; i < amount; i++)
        {
            SimplePool.Despawn(currentBrickonMap[i]);
        }
        currentBrickonMap.Clear();
        checkSpawned.Clear();
    }
    public void RemoveColorFromBeingRespawned(ColorType colorType)
    {
        this.colorToSpawn.Remove(colorType);
    }
}
