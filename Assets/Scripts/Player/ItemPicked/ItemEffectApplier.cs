using System;
using Items;
using UI;
using UnityEngine;
using Weapons;
using Weapons.Configs;

namespace Player.ItemPicked
{
    public class ItemEffectApplier
    {
        private readonly PlayerStatsHolder _playerStatsHolder;
        private readonly ExpAccumulator _expAccumulator;
        private readonly IWeaponUpgrader _weaponUpgrader;

        public ItemEffectApplier(PlayerStatsHolder playerStatsHolder, ExpAccumulator expAccumulator,
            IWeaponUpgrader weaponUpgrader)
        {
            _playerStatsHolder = playerStatsHolder;
            _expAccumulator = expAccumulator;
            _weaponUpgrader = weaponUpgrader;
        }

        public void ApplyWeapon(WeaponItemConfig weaponItem)
        {
            Debug.Log($"Picked up {weaponItem.Name}.");
            _weaponUpgrader.UpdateWeapon(weaponItem);
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