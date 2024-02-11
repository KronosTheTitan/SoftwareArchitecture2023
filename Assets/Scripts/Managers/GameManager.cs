using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    /// <summary>
    /// singleton that allows interaction with player data like health and money.
    /// </summary>
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
            EventBus<OnEnemyDestroyed>.OnEvent += ReceiveIncome;
            EventBus<OnEnemyReachedEnd>.OnEvent += TakeDamage;
        }

        private void OnDisable()
        {
            EventBus<OnEnemyDestroyed>.OnEvent -= ReceiveIncome;
            EventBus<OnEnemyReachedEnd>.OnEvent -= TakeDamage;
        }

        private void ReceiveIncome(OnEnemyDestroyed onEnemyDestroyed)
        {
            money += onEnemyDestroyed.EnemyType.CarriedMoney;
            EventBus<OnPlayerIncomeModified>.Publish(new OnPlayerIncomeModified(money));
        }

        private void TakeDamage(OnEnemyReachedEnd onEnemyReachedEnd)
        {
            int amount = 1;
            healthRemaining -= amount;
        
            if(healthRemaining <= 0)
                EventBus<OnGameEnd>.Publish(new OnGameEnd(false));

            EventBus<OnPlayerTakeDamage>.Publish(new OnPlayerTakeDamage(healthRemaining, amount));
        }

        public void SpendMoney(int amount)
        {
            money -= amount;
            EventBus<OnPlayerIncomeModified>.Publish(new OnPlayerIncomeModified(money));
        }
    }
}