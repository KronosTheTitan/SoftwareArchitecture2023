using System;
using TMPro;
using UnityEngine;

public class MoneyFromEnemy : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public void Setup(int amount)
    {
        text.text = "+" + amount.ToString();
    }

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}
