using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private EnemyType type;
    [SerializeField] private bool isWeaknessEffectActive;
    [SerializeField] private bool isDead;
    public int CurrentHealth => currentHealth;
    public bool IsWeaknessEffectActive => isWeaknessEffectActive;
    public bool IsDead => isDead;

    private void Start()
    {
        EventBus.CallOnEnemySpawn(this);
    }

    public void TakeDamage(int amount)
    {
        if (isWeaknessEffectActive)
            amount *= 2;
        currentHealth -= amount;
        if(currentHealth >= 0)
            return;

        EventBus.CallOnEnemyDestroyed(type);
        isDead = true;
        gameObject.SetActive(false);
    }

    public void ApplyWeakness()
    {
        if(isWeaknessEffectActive)
            return;

        isWeaknessEffectActive = true;
    }
}
