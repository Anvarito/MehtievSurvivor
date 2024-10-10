using System;
using TMPro;
using UnityEngine;
using Zenject;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healText;
    [SerializeField] private TextMeshProUGUI _speedText;

    private PlayerStatsHolder _playerStatsHolder;
    
    [Inject]
    private void Construct(PlayerStatsHolder playerStatsHolder)
    {
        _playerStatsHolder = playerStatsHolder;
    }

    private void Awake()
    {
        _playerStatsHolder.CurrentHP.Changed += HealChange;
        _playerStatsHolder.Speed.Changed += SpeedChange;
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