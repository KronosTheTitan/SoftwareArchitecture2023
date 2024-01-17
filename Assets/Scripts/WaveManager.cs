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
        building
    }

    [SerializeField] private phase currentPhase = phase.building;
    
    private void Start()
    {
        EventBus.OnEnemyDestroyed += RemoveEnemy;
        EventBus.OnEnemyReachedEnd += RemoveEnemy;
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
        
        EventBus.CallOnEndWave(buildPhaseLength);
        currentPhase = phase.building;
        buildPhaseStartTime = Time.time;
    }

    private void StartWave()
    {
        waveNumber++;

        activeWave = waves[waveNumber];
        
        activeEnemies = NumberOfEnemiesInWave(activeWave);
        
        EventBus.CallOnStartWave(activeWave, waveNumber);
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

    /// <summary>
    /// these functions is used to keep track of when enemies are destroyed to ensure that waves don't end prematurely.
    /// </summary>
    /// <param name="type">This parameter does not matter, this is just info it takes in from the OnEnemyDestroyed
    /// event, other functions rely on that information to take their actions.</param>
    private void RemoveEnemy(EnemyType type)
    {
        activeEnemies--;
    }

    /// <summary>
    /// Used in detecting when a wave has been finished.
    /// </summary>
    private void RemoveEnemy()
    {
        activeEnemies--;
    }
}