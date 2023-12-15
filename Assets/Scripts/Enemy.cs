using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    public int CurrentHealth => currentHealth;
}
