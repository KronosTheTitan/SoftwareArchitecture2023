public class EventBus
{
    public static event PlayerTakeDamage OnPlayerTakeDamage;
    public delegate void PlayerTakeDamage(int newHealth, int damageTaken);
    
    public static event PlayerReceiveIncome OnPlayerReceiveIncome;
    public delegate void PlayerReceiveIncome(int newMoney);

    public static event EnemyDestroyed OnEnemyDestroyed;
    public delegate void EnemyDestroyed(EnemyType enemyType);
    public static event EnemyReachedEnd OnEnemyReachedEnd;
    public delegate void EnemyReachedEnd();

    public static event StartWave OnStartWave;
    public delegate void StartWave(Wave wave, int waveNumber);

    public static event EndWave OnEndWave;

    public delegate void EndWave(float buildTimeLength);

    public static event EnemySpawn OnEnemySpawn;
    public delegate void EnemySpawn(Enemy enemy);

    public static void CallOnPlayerTakeDamage(int newHealth, int damageTaken)
    {
        OnPlayerTakeDamage?.Invoke(newHealth, damageTaken);
    }
    public static void CallOnPlayerReceiveIncome(int newMoney)
    {
        OnPlayerReceiveIncome?.Invoke(newMoney);
    }

    public static void CallOnEnemyDestroyed(EnemyType enemyType)
    {
        OnEnemyDestroyed?.Invoke(enemyType);
    }

    public static void CallOnEnemyReachedEnd()
    {
        OnEnemyReachedEnd?.Invoke();
    }

    public static void CallOnStartWave(Wave wave, int waveNumber)
    {
        OnStartWave?.Invoke(wave, waveNumber);
    }
    
    public static void CallOnEndWave(float durationOfBuildPhase)
    {
        OnEndWave?.Invoke(durationOfBuildPhase);
    }

    public static void CallOnEnemySpawn(Enemy enemy)
    {
        OnEnemySpawn?.Invoke(enemy);
    }
}