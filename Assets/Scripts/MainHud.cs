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
        EventBus<OnPlayerTakeDamage>.OnEvent += UpdatePlayerHealthBar;
        EventBus<OnPlayerReceivedIncome>.OnEvent += UpdateMoneyNumber;
        EventBus<OnStartWave>.OnEvent += DisableBuildTimeBar;
        EventBus<OnStartWave>.OnEvent += UpdateWaveNumber;
        
        EventBus<OnEndWave>.OnEvent += EnableBuildTimeBar;
    }

    private void Update()
    {
        buildTimeRemaining.value = (buildTimeRemaining.maxValue + buildPhaseStartTime) - Time.time;
    }

    private void UpdatePlayerHealthBar(OnPlayerTakeDamage onPlayerTakeDamage)
    {
        playerHealthBar.value = onPlayerTakeDamage.NewHealth;
    }

    private void UpdateMoneyNumber(OnPlayerReceivedIncome onPlayerReceivedIncome)
    {
        moneyNumberText.text = onPlayerReceivedIncome.NewMoney.ToString();
    }

    private void UpdateWaveNumber(Wave wave, int waveNumber)
    {
        waveNumberText.text = (waveNumber + 1).ToString();
    }
    
    private void UpdateWaveNumber(OnStartWave onStartWave)
    {
        waveNumberText.text = (onStartWave.WaveNumber + 1).ToString();
    }

    private void EnableBuildTimeBar(OnEndWave onEndWave)
    {
        buildTimeRemaining.gameObject.SetActive(true);

        buildPhaseStartTime = Time.time;
        
        buildTimeRemaining.minValue = 0;
        buildTimeRemaining.maxValue = onEndWave.BuildTimeLength;
        buildTimeRemaining.value = (onEndWave.BuildTimeLength + buildPhaseStartTime) - Time.time;
    }

    private void DisableBuildTimeBar(OnStartWave onStartWave)
    {
        DisableBuildTimeBar(onStartWave.Wave, onStartWave.WaveNumber);
    }
    private void DisableBuildTimeBar(Wave wave, int waveNumber)
    {
        buildTimeRemaining.gameObject.SetActive(false);
    }
}