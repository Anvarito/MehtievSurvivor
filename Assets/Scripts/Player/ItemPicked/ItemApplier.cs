using Items;
using Player.PlayerStats;
using UI;
using UnityEngine;
using Weapons;

namespace Player.ItemPicked
{
    public class ItemApplier
    {
        private readonly ExpAccumulator _expAccumulator;
        private readonly IEffectUpgrader _effectUpgrader;
        private readonly IWeaponUpgrader _weaponUpgrader;

        public ItemApplier(ExpAccumulator expAccumulator, IEffectUpgrader effectUpgrader,
            IWeaponUpgrader weaponUpgrader)
        {
            _expAccumulator = expAccumulator;
            _effectUpgrader = effectUpgrader;
            _weaponUpgrader = weaponUpgrader;
        }

        public void ApplyWeaponItem(WeaponItemConfig weaponItem)
        {
            Debug.Log($"Picked up {weaponItem.Name}.");
            _weaponUpgrader.UpdateOrAdd(weaponItem);
        }

        public void ApplyEffectItem(StatItemConfig statItemConfig)
        {
            Debug.Log($"Picked up {statItemConfig.Name}, {statItemConfig.Description}");
            _effectUpgrader.ApplyEffectItem(statItemConfig);
        }

        public void ApplyPowerUp(StatItemConfig statItemConfig)
        {
            Debug.Log($"Picked power up {statItemConfig.Name}, {statItemConfig.Description}");
            _effectUpgrader.EncreaceStat(statItemConfig);
        }

        public void ApplyExp(ExpItem expItem)
        {
            Debug.Log($"Gain the expirience.");
            _expAccumulator.EncreaseExp(expItem.Points);
        }
    }
}