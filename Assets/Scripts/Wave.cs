using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct Entry
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private int quantity;

    public EnemyType EnemyType => enemyType;
    public int Quantity => quantity;
}

[CreateAssetMenu(fileName = "New Wave", menuName = "SoftwareArchitecture/Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] private Entry[] enemiesInWave;
    public Entry[] EnemiesInWave => enemiesInWave;

    [SerializeField] private float timeBetweenSpawns;
    public float TimeBetweenSpawns => timeBetweenSpawns;
}
