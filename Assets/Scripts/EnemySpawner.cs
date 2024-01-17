using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Path path;
    public Path Path => path;
    
    [SerializeField] private Wave activeWave;
    [SerializeField] private float lastSpawn;
    [SerializeField] private int currentEnemy;
    [SerializeField] private List<EnemyType> remainingEnemies;
    [SerializeField] private Enemy enemyTemplate;

    private void Start()
    {
        EventBus.OnStartWave += StartWave;
    }

    private void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if(lastSpawn + activeWave.TimeBetweenSpawns >= Time.time)
            return;
        
        if (currentEnemy >= remainingEnemies.Count)
            return;

        lastSpawn = Time.time;
        
        EnemyType nextType = remainingEnemies[currentEnemy];

        Enemy enemy = Instantiate(enemyTemplate);
        
        enemy.Setup(nextType, path);
        
        currentEnemy++;
    }

    private void StartWave(Wave wave, int waveNumber)
    {
        remainingEnemies.Clear();

        currentEnemy = 0;
            
        activeWave = wave;
            
        foreach (Entry entry in activeWave.EnemiesInWave)
        {
            for (int i = 0; i < entry.Quantity; i++)
            {
                remainingEnemies.Add(entry.EnemyType);
            }
        }
    }
}