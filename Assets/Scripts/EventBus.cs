public class EventBus
{
    public static event PlayerTakeDamage OnPlayerTakeDamage ;
    public delegate void PlayerTakeDamage(int newHealth, int damageTaken);
        
    public static event EnemyDestroyed OnEnemyDestroyed ;
    public delegate void EnemyDestroyed(EnemyType enemyType);

    public static event StartWave OnStartWave;
    public delegate void StartWave();

    public static event EnemySpawn OnEnemySpawn;
    public delegate void EnemySpawn(Enemy enemy);

    public static void CallOnPlayerTakeDamage(int newHealth, int damageTaken)
    {
        OnPlayerTakeDamage?.Invoke(newHealth, damageTaken);
    }

    public static void CallOnEnemyDestroyed(EnemyType enemyType)
    {
        OnEnemyDestroyed?.Invoke(enemyType);
    }

    public static void CallOnStartWave()
    {
        OnStartWave?.Invoke();
    }

    public static void CallOnEnemySpawn(Enemy enemy)
    {
        OnEnemySpawn?.Invoke(enemy);
    }
}