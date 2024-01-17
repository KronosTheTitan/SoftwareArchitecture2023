using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainHud : MonoBehaviour
{
    [SerializeField] private Slider playerHealthBar;
    [SerializeField] private Slider buildTimeRemaining;

    [SerializeField] private TMP_Text waveNumberText;
    [SerializeField] private TMP_Text moneyNumberText;

    [SerializeField] private float buildPhaseStartTime;

    private void Start()
    {
        EventBus.OnPlayerTakeDamage += UpdatePlayerHealthBar;
        EventBus.OnPlayerReceiveIncome += UpdateMoneyNumber;
        EventBus.OnStartWave += UpdateWaveNumber;
        EventBus.OnStartWave += DisableBuildTimeBar;
        EventBus.OnEndWave += EnableBuildTimeBar;
    }

    private void Update()
    {
        buildTimeRemaining.value = (buildTimeRemaining.maxValue + buildPhaseStartTime) - Time.time;
    }

    private void UpdatePlayerHealthBar(int newHealth, int damageTaken)
    {
        playerHealthBar.value = newHealth;
    }

    private void UpdateMoneyNumber(int newMoney)
    {
        moneyNumberText.text = newMoney.ToString();
    }

    private void UpdateWaveNumber(Wave wave, int waveNumber)
    {
        waveNumberText.text = (waveNumber + 1).ToString();
    }

    private void EnableBuildTimeBar(float buildTimeLength)
    {
        buildTimeRemaining.gameObject.SetActive(true);

        buildPhaseStartTime = Time.time;
        
        buildTimeRemaining.minValue = 0;
        buildTimeRemaining.maxValue = buildTimeLength;
        buildTimeRemaining.value = (buildTimeLength + buildPhaseStartTime) - Time.time;
    }

    private void DisableBuildTimeBar(Wave wave, int waveNumber)
    {
        buildTimeRemaining.gameObject.SetActive(false);
    }
}