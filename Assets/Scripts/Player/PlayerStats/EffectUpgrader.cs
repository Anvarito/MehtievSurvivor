using Items;
using UnityEngine;

namespace Player.PlayerStats
{
    public class EffectUpgrader : IEffectUpgrader
    {
        private readonly PlayerStatsHolder _playerStatsHolder;
        private readonly IEffectContainer _effectContainer;

        public EffectUpgrader(PlayerStatsHolder playerStatsHolder, IEffectContainer effectContainer)
        {
            _playerStatsHolder = playerStatsHolder;
            _effectContainer = effectContainer;
        }

        public void ApplyEffect(StatItemConfig statItemConfig)
        {
            Debug.Log($"Picked up {statItemConfig.Name}, {statItemConfig.Description}");
            
            if (!_effectContainer.CheckEffect(statItemConfig.StatType))
            {
                _effectContainer.AddStatItem(statItemConfig);
            }

            EncreaseStat(statItemConfig);
        }

        private void EncreaseStat(StatItemConfig statItemConfig)
        {
            if (statItemConfig.StatType == EStatType.HP)
            {
                _playerStatsHolder.CurrentHP.value += statItemConfig.EffectAmount;
            }

            if (statItemConfig.StatType == EStatType.Speed)
            {
                _playerStatsHolder.Speed.value += statItemConfig.EffectAmount;
            }
        }
    }
}