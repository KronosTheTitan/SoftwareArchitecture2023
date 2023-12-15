using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    #region Singleton
    private static EnemyManager _instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject); // Destroy this object if another instance exists.
        else
            _instance = this; // Set this as the singleton instance.
        SceneManager.sceneUnloaded += MemoryLeakPrevention;
    }

    /// <summary>
    /// Gets the singleton instance of the GameManager.
    /// </summary>
    /// <returns>The GameManager instance.</returns>
    public static EnemyManager GetInstance()
    {
        return _instance;
    }

    private void MemoryLeakPrevention(Scene scene)
    {
        _instance = null;
    }
    
    #endregion
    
    private readonly Queue<Enemy> _enemies = new Queue<Enemy>();

    [SerializeField] private Path path;
    
    public Enemy[] Enemies => _enemies.ToArray();
    public Path Path => path;

    private void Start()
    {
        EventBus.OnEnemySpawn += AddEnemy;
    }

    private void AddEnemy(Enemy enemy)
    {
        _enemies.Enqueue(enemy);
    }

    public Enemy GetFurthestEnemyWithinRange(Vector3 origin, float range)
    {
        foreach (Enemy enemy in _enemies)
        {
            if(enemy.IsDead)
                continue;
            
            Vector3 enemyPos = enemy.transform.position;
            float distance = (origin - enemyPos).magnitude;
            if (distance <= range)
                return enemy;
        }

        return null;
    }
}