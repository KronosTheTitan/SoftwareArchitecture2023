using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct Entry
{
    [FormerlySerializedAs("enemyType")] [SerializeField] private EnemyType enemyTypeType;
    [SerializeField] private int quantity;
}

[CreateAssetMenu(fileName = "New Wave", menuName = "SoftwareArchitecture/Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] private Entry[] enemiesInWave;
    public Entry[] EnemiesInWave => enemiesInWave;
}
