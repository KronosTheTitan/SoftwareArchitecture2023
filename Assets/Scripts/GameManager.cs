using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        
    #region Singleton
    private static GameManager _instance;

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
    public static GameManager GetInstance()
    {
        return _instance;
    }

    private void MemoryLeakPrevention(Scene scene)
    {
        _instance = null;
    }
    
    #endregion

    [SerializeField] private int healthRemaining;
    [SerializeField] private int money;

    public int Money => money;

    private void Start()
    {
        EventBus.OnEnemyDestroyed += ReceiveIncome;
        EventBus.OnEnemyReachedEnd += TakeDamage;
    }

    private void ReceiveIncome(EnemyType type)
    {
        money += type.CarriedMoney;
        EventBus.CallOnPlayerReceiveIncome(money);
    }

    private void TakeDamage()
    {
        int amount = 1;
        healthRemaining -= amount;
        
        if(healthRemaining <= 0)
            Debug.LogError("Player Defeated");
        
        EventBus.CallOnPlayerTakeDamage(healthRemaining ,amount);
    }
}