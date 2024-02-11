using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private Wave activeWave;
    
    [SerializeField] private int waveNumber = 0;
    [SerializeField] private int activeEnemies;

    [SerializeField] private float buildPhaseStartTime;
    [SerializeField] private float buildPhaseLength;

    private enum phase
    {
        combat,
        building,
        end
    }

    [SerializeField] private phase currentPhase = phase.building;
    
    private void Awake()
    {
        EventBus<OnEnemyDestroyed>.OnEvent += RemoveEnemy;
        EventBus<OnEnemyReachedEnd>.OnEvent += RemoveEnemy;
    }

    private void Start()
    {
        buildPhaseStartTime = Time.time;
        EventBus<OnGameStart>.Publish(new OnGameStart(buildPhaseLength));
    }

    private void OnDisable()
    {
        EventBus<OnEnemyDestroyed>.OnEvent += RemoveEnemy;
        EventBus<OnEnemyReachedEnd>.OnEvent += RemoveEnemy;
    }

    private void Update()
    {
        if (currentPhase == phase.building)
        {
            BuildingPhaseUpdate();
            return;
        }

        if (currentPhase == phase.combat)
        {
            CombatPhaseUpdate();
            return;
        }
    }

    private void BuildingPhaseUpdate()
    {
        if(Time.time <= buildPhaseStartTime + buildPhaseLength)
            return;
        
        StartWave();
        currentPhase = phase.combat;
    }

    private void CombatPhaseUpdate()
    {
        if(activeEnemies != 0)
            return;

        if (waveNumber >= waves.Length - 1)
        {
            EventBus<OnGameEnd>.Publish(new OnGameEnd(true));
        }
        
        EventBus<OnEndWave>.Publish(new OnEndWave(buildPhaseLength));
        currentPhase = phase.building;
        buildPhaseStartTime = Time.time;
    }

    private void StartWave()
    {
        waveNumber++;

        activeWave = waves[waveNumber];
        
        activeEnemies = NumberOfEnemiesInWave(activeWave);
        EventBus<OnStartWave>.Publish(new OnStartWave(activeWave, waveNumber));
       //EventBus.CallOnStartWave(activeWave, waveNumber);
    }

    /// <summary>
    /// Returns the amount of enemies that will be spawned during the provided waves.
    /// </summary>
    /// <param name="wave">The wave that will be checked against.</param>
    /// <returns>the number of enemies in that wave.</returns>
    private int NumberOfEnemiesInWave(Wave wave)
    {
        int i = 0;

        foreach (Entry entry in wave.EnemiesInWave)
        {
            i += entry.Quantity;
        }

        return i;
    }
    
    private void RemoveEnemy(OnEnemyDestroyed onEnemyDestroyed)
    {
        activeEnemies--;
    }
    
    private void RemoveEnemy(OnEnemyReachedEnd onEnemyReachedEnd)
    {
        activeEnemies--;
    }
}