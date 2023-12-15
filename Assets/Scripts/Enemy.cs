using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private EnemyType type;
    [SerializeField] private bool isWeaknessEffectActive;
    [SerializeField] private bool isDead;
    [SerializeField] private float position;
    [SerializeField] private new MeshRenderer renderer;
    public int CurrentHealth => currentHealth;
    public bool IsWeaknessEffectActive => isWeaknessEffectActive;
    public bool IsDead => isDead;

    private void Start()
    {
        EventBus.CallOnEnemySpawn(this);
    }

    private void Update()
    {
        Move();
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
        renderer.enabled = false;
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
        Vector3 newPos = EnemyManager.GetInstance().Path.GetPointOnSpline(position);
        if (newPos == transform.position)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.position = newPos;
        }
    }
}
