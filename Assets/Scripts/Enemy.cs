using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private EnemyType type;
    [SerializeField] private bool isWeaknessEffectActive;
    [SerializeField] private bool isDead;
    [SerializeField] private float position;
    [SerializeField] private Path path;
    public int CurrentHealth => currentHealth;
    public bool IsWeaknessEffectActive => isWeaknessEffectActive;
    public bool IsDead => isDead;
    public float Position => position;

    private void Update()
    {
        Move();
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Took damage");
        if (isWeaknessEffectActive)
            amount *= 2;
        currentHealth -= amount;
        if(currentHealth > 0)
            return;

        EventBus<OnEnemyDestroyed>.Publish(new OnEnemyDestroyed(type));
        Destroy(gameObject);
    }

    public void ApplyWeakness()
    {
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
    }
}