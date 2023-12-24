using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainHud : MonoBehaviour
{
    [SerializeField] private Slider playerHealthBarOuter;
    [SerializeField] private Slider playerHealthBarInner;
    [SerializeField] private Slider buildTimeRemaining;

    [SerializeField] private TMP_Text waveNumber;
    [SerializeField] private TMP_Text moneyNumber;

    private void Start()
    {
        EventBus.OnPlayerTakeDamage += UpdatePlayerHealthBar;
    }
    
    private void Update()
    {
        playerHealthBarInner.value = Mathf.Lerp(playerHealthBarInner.value, playerHealthBarOuter.value, Time.time);
    }

    private void UpdatePlayerHealthBar(int newHealth, int damageTaken)
    {
        playerHealthBarOuter.value = newHealth;
    }
}