using System;
using Building;
using Enemies;
using Managers;

/// <summary>
/// the base event class all others are derived from
/// </summary>
public abstract class Event{
    
}

/// <summary>
/// Called when a new wave starts
/// </summary>
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

/// <summary>
/// called when the player takes damage
/// </summary>
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

/// <summary>
/// called when the players income is modified.
/// </summary>
public class OnPlayerIncomeModified : Event
{
    public readonly int NewMoney;

    public OnPlayerIncomeModified(int pNewMoney)
    {
        NewMoney = pNewMoney;
    }
}

/// <summary>
/// called when an enemy has reached the end of its path
/// </summary>
public class OnEnemyReachedEnd : Event
{
    
}

/// <summary>
/// called when the player has destroyed an enemy
/// </summary>
public class OnEnemyDestroyed : Event
{
    public readonly EnemyType EnemyType;
    public OnEnemyDestroyed(EnemyType pEnemyType)
    {
        EnemyType = pEnemyType;
    }
}

/// <summary>
/// called when a wave ends
/// </summary>
public class OnEndWave : Event
{
    public readonly float BuildTimeLength;

    public OnEndWave(float pBuildTimeLength)
    {
        BuildTimeLength = pBuildTimeLength;
    }
}

/// <summary>
/// called when the last wave has ended.
/// </summary>
public class OnGameEnd : Event
{
    public readonly bool isVictory;

    public OnGameEnd(bool pIsVictory)
    {
        isVictory = pIsVictory;
    }
}

/// <summary>
/// called when the game scene is loaded.
/// </summary>

public class OnGameStart : Event
{
    public readonly float buildPhaseLength;

    public OnGameStart(float pBuildPhaseLength)
    {
        buildPhaseLength = pBuildPhaseLength;
    }
}

public class OnToolSelected : Event
{
    public readonly BuildTool tool;

    public OnToolSelected(BuildTool pTool)
    {
        tool = pTool;
    }
}

public class OnToolDeselected : Event
{
    
}

public class ShowToolTip : Event
{
    public readonly ToolTipTrigger trigger;

    public ShowToolTip(ToolTipTrigger pTrigger)
    {
        trigger = pTrigger;
    }
}

public class HideToolTip : Event
{
    
}

/// <summary>
/// This class is used for receiving and sending events from other parts of the code base
/// </summary>
/// <typeparam name="T">The event targeted either in subscribing or publishing</typeparam>
public class EventBus<T> where T : Event
{
    public static event Action<T> OnEvent;

    public static void Publish(T pEvent)
    {
        OnEvent?.Invoke(pEvent);
    }
}