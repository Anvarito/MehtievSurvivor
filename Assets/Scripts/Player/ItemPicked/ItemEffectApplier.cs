using HitPointsDamage;
using Items;
using UnityEngine;

namespace Player.PlayerStats
{
    public class ItemEffectApplier
    {
        private readonly StatsBar _statsBar;
        private readonly PlayerStatsData _playerStatsData;
        private readonly IHitPoints _playerHitPointsHolder;
        private readonly PlayerMovement _playerMovement;

        public ItemEffectApplier(
            StatsBar statsBar, 
            PlayerStatsData playerStatsData, 
            IHitPoints playerHitPointsHolder, 
            PlayerMovement playerMovement
            )
        {
            _statsBar = statsBar;
            _playerStatsData = playerStatsData;
            _playerHitPointsHolder = playerHitPointsHolder;
            _playerMovement = playerMovement;

            InitAllView();
        }

        private void InitAllView()
        {
            _statsBar.SpeedChange(_playerStatsData.Speed);
            _statsBar.HealChange(_playerStatsData.HP);
        }
        public void ApplyWeapon(WeaponItemConfig weaponItemConfig)
        {
            //weaponItemConfig.Config
            Debug.Log($"Picked up {weaponItemConfig.Name}.");
        }

        public void ApplyStatsUp(StatItemConfig statItemConfig)
        {
            Debug.Log($"Picked up {statItemConfig.Name}, {statItemConfig.Description}");
            
            if (statItemConfig.StatType == EStatType.HP)
            {
                _playerHitPointsHolder.IncreaseHP(statItemConfig.EffectAmount);
            }

            if (statItemConfig.StatType == EStatType.Speed)
            {
                _playerMovement.IncreaseSpeed(statItemConfig.EffectAmount);
            }
        }

        public void ApplyExp(ExpItem expItem)
        {
            Debug.Log($"Gain the expirience.");
        }
    }
}