using System;
using Items;
using UI;
using UnityEngine;
using Weapons.Configs;

namespace Player.ItemPicked
{
    public class ItemEffectApplier
    {
        private readonly PlayerStatsHolder _playerStatsHolder;
        private readonly ExpAccumulator _expAccumulator;
        private readonly WeaponUpgradeController _weaponUpgradeController;

        public ItemEffectApplier(PlayerStatsHolder playerStatsHolder, ExpAccumulator expAccumulator, WeaponUpgradeController weaponUpgradeController)
        {
            _playerStatsHolder = playerStatsHolder;
            _expAccumulator = expAccumulator;
            _weaponUpgradeController = weaponUpgradeController;
        }
        
        public void ApplyWeapon(WeaponConfig weaponConfig)
        {
            Debug.Log($"Picked up {weaponConfig.Name}.");
            _weaponUpgradeController.ApplyWeapon(weaponConfig);
        }

        public void ApplyStatsUp(StatItemConfig statItemConfig)
        {
            Debug.Log($"Picked up {statItemConfig.Name}, {statItemConfig.Description}");
            
            if (statItemConfig.StatType == EStatType.HP)
            {
                _playerStatsHolder.CurrentHP.value += statItemConfig.EffectAmount;
            }

            if (statItemConfig.StatType == EStatType.Speed)
            {
                _playerStatsHolder.Speed.value += statItemConfig.EffectAmount;
            }
        }

        public void ApplyExp(ExpItem expItem)
        {
            Debug.Log($"Gain the expirience.");
            _expAccumulator.EncreaseExp(expItem.Points);
        }
    }
}