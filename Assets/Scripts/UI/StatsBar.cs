using System;
using TMPro;
using UnityEngine;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healText;
    [SerializeField] private TextMeshProUGUI _speedText;

    private PlayerStatsHolder _playerStatsHolder;
    public void SetDataHolder(PlayerStatsHolder playerStatsHolder)
    {
        _playerStatsHolder = playerStatsHolder;
        
        _playerStatsHolder.CurrentHP.Changed += HealChange;
        _playerStatsHolder.Speed.Changed += SpeedChange;
    }

    private void Awake()
    {
        HealChange(_playerStatsHolder.CurrentHP.value);
        SpeedChange(_playerStatsHolder.Speed.value);
    }

    private void OnDestroy()
    {
        _playerStatsHolder.CurrentHP.Changed -= HealChange;
        _playerStatsHolder.Speed.Changed -= SpeedChange;
    }

    public void HealChange(float count)
    {
        _healText.text = "HP: " + count;
    }

    public void SpeedChange(float count)
    {
        _speedText.text = "Speed: " + count;
    }

    
}