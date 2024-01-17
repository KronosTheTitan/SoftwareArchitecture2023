using System;

public abstract class Event{
    
}

public class OnStartWave : Event
{
    public readonly Wave Wave;
    public readonly int WaveNumber;
    public OnStartWave(Wave pWave, int pWaveNumber)
    {
        Wave = pWave;
        WaveNumber = pWaveNumber;
    }
}

public class OnPlayerTakeDamage : Event
{
    public readonly int NewHealth;
    public readonly int DamageTaken;
    public OnPlayerTakeDamage(int pNewHealth, int pDamageTaken)
    {
        NewHealth = pNewHealth;
        DamageTaken = pDamageTaken;
    }
}

public class OnPlayerReceivedIncome : Event
{
    public readonly int NewMoney;

    public OnPlayerReceivedIncome(int pNewMoney)
    {
        NewMoney = pNewMoney;
    }
}

public class OnEnemyReachedEnd : Event
{
    
}

public class OnEnemyDestroyed : Event
{
    public readonly EnemyType EnemyType;
    public OnEnemyDestroyed(EnemyType pEnemyType)
    {
        EnemyType = pEnemyType;
    }
}

public class OnEndWave : Event
{
    public readonly float BuildTimeLength;

    public OnEndWave(float pBuildTimeLength)
    {
        BuildTimeLength = pBuildTimeLength;
    }
}

public class EventBus<T> where T : Event
{
    public static event Action<T> OnEvent;

    public static void Publish(T pEvent)
    {
        OnEvent?.Invoke(pEvent);
    }
}