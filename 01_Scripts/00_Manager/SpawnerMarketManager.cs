using System;
using System.Collections;
using System.Collections.Generic;
using Blacktool.Utils;
using Blacktool.Utils.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerMarketManager : MonoBehaviour
{
    public List<MarketItem> items;
    
    public List<GameObject> itemsToSpawn;

    public AnimationCurve progressionValueLevel;

    public float TimeBTWWave;

    public int currentWave;
    public int currentWaveValue;

    public Transform spawnCenter;
    public float spawnRadius;
    
    private Timer t_SpawnTimer;
    public float d_TimeBtwSpawn;
    public void Start()
    {
        t_SpawnTimer = new Timer(d_TimeBtwSpawn,StartSpawning);
        currentWave = 13;
        SetWaves();
    }
    

    public void SetWaves()
    {
        currentWaveValue = Mathf.RoundToInt(progressionValueLevel.Evaluate(currentWave));
        PrepareSpawnElement();
        t_SpawnTimer.ResetPlay();
        //FindObjectOfType<ScoreManager>().UpdateScoreMultiplicator(currentWave);
        //FindObjectOfType<LevelManager>().SetMaxValue( 
          //  FindObjectOfType<LevelManager>().TimeBetweenSpawn.Max - (currentWave * 3) / 60);
    }

    private void StartSpawning()
    {
        Vector3 pos = RandomCircleMethods.PointOnAUnitCircle(spawnRadius);
        pos += spawnCenter.position;
        GetItem(pos);
    }

    private void PrepareSpawnElement()
    {
        int copyMoney = currentWaveValue;
        int value = 0;
        while (copyMoney > 0)
        {
            value = GetSpawnElement(copyMoney);
            copyMoney -= value;
        }
    }

    private int GetSpawnElement(int copyMoney)
    {
        int randomIndex = Random.Range(0, items.Count);
        if(copyMoney >= items[randomIndex].value)
            itemsToSpawn.Add(items[randomIndex].item);
        return items[randomIndex].value;
    }

    public void GetItem(Vector3 transformPosition)
    {
        if (itemsToSpawn.Count <= 1)
        {
            currentWave++;
            SetWaves();
        }
        int randomItem = Random.Range(0, itemsToSpawn.Count);
        GameObject elementToSpawn = itemsToSpawn[randomItem];

        Instantiate(elementToSpawn, transformPosition, Quaternion.identity);
        itemsToSpawn.RemoveAt(randomItem);
        t_SpawnTimer.ResetPlay();

    }
}


[System.Serializable]
public class MarketItem
{
    public int value;
    public GameObject item;
}