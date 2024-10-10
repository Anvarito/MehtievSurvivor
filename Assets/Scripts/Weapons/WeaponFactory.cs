using Items;
using UnityEngine;
using Zenject;

namespace Weapons
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly WeaponRootTransform _weaponRootTransform;
        private readonly PlayerStatsHolder _playerStatsHolder;

        public WeaponFactory(WeaponRootTransform weaponRootTransform,
            PlayerStatsHolder playerStatsHolder)
        {
            _weaponRootTransform = weaponRootTransform;
            _playerStatsHolder = playerStatsHolder;
        }

        public WeaponParamsHandler CreateNewWeapon(WeaponItemConfig itemConfig)
        {
            BaseWeapon weapon = Object.Instantiate(itemConfig.WeaponPrefab, _weaponRootTransform.transform);
            WeaponParamsHandler weaponParamsHandler = new WeaponParamsHandler(itemConfig.WeaponConfig, weapon, _playerStatsHolder);
            return weaponParamsHandler;
        }
    }
}