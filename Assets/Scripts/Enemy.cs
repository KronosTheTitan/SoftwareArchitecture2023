using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private EnemyType type;
    [SerializeField] private bool isWeaknessEffectActive;
    [SerializeField] private bool isDead;
    [SerializeField] private float position;
    [SerializeField] private Path path;
    [SerializeField] private MoneyFromEnemy moneyDropText;
    [SerializeField] private Slider healthBar;
    public int CurrentHealth => currentHealth;
    public bool IsWeaknessEffectActive => isWeaknessEffectActive;
    public bool IsDead => isDead;
    public float Position => position;

    private void Update()
    {
        Move();
        DetectDeath();
    }

    private void DetectDeath()
    {
        if(currentHealth > 0)
            return;

        EventBus<OnEnemyDestroyed>.Publish(new OnEnemyDestroyed(type));
        Instantiate(moneyDropText, transform.position, quaternion.identity).Setup(type.CarriedMoney);
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        if (isWeaknessEffectActive)
            amount *= 2;
        currentHealth -= amount;

        healthBar.value = currentHealth;
    }
    
    public void ApplyWeakness()
    {
        Debug.Log("Weakness Applied");
        
        if(isWeaknessEffectActive)
            return;

        isWeaknessEffectActive = true;
    }
    
    private void Move()
    {
        position += type.Speed * Time.deltaTime;
        Vector3 newPos = path.GetPointOnSpline(position);
        if (newPos == transform.position)
        {
            EventBus<OnEnemyReachedEnd>.Publish(new OnEnemyReachedEnd());
            Destroy(gameObject);
        }
        else
        {
            transform.position = newPos;
        }
    }

    public void Setup(EnemyType enemyType, Path newPath)
    {
        type = enemyType;
        path = newPath;
        transform.position = path.GetPointOnSpline(0);
        currentHealth = type.Health;
        GameObject gameObject = Instantiate(type.GFX, transform);
        gameObject.transform.position = transform.position;
        healthBar.maxValue = type.Health;
        healthBar.value = type.Health;
    }
}