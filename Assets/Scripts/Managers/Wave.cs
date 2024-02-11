using System;
using Enemies;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// a pair of type and quantity that determines how often a specific type of enemy will appear in a wave.
    /// </summary>
    [Serializable]
    public struct Entry
    {
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private int quantity;

        public EnemyType EnemyType => enemyType;
        public int Quantity => quantity;
    }

    /// <summary>
    /// a wave of enemies that is used by the spawner to spawn enemies.
    /// </summary>
    [CreateAssetMenu(fileName = "New Wave", menuName = "SoftwareArchitecture/Wave")]
    public class Wave : ScriptableObject
    {
        [SerializeField] private Entry[] enemiesInWave;
        public Entry[] EnemiesInWave => enemiesInWave;

        [SerializeField] private float timeBetweenSpawns;
        public float TimeBetweenSpawns => timeBetweenSpawns;
    }
}