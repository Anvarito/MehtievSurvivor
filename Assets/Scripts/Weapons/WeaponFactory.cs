using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;
using Weapons.Configs;
using Zenject;

namespace Weapons
{
    public class WeaponFactory : IInitializable, IWeaponFactory
    {
        private readonly WeaponItemConfig _defaultWeaponItem;
        private readonly WeaponRootTransform _weaponRootTransform;
        private readonly PlayerStatsHolder _playerStatsHolder;
        private List<WeaponParamsHandler> _weaponsContainers = new();

        public WeaponFactory(WeaponItemConfig defaultWeaponItem, WeaponRootTransform weaponRootTransform,
            PlayerStatsHolder playerStatsHolder)
        {
            _defaultWeaponItem = defaultWeaponItem;
            _weaponRootTransform = weaponRootTransform;
            _playerStatsHolder = playerStatsHolder;
        }
        public void Initialize()
        {
            CreateNewWeapon(_defaultWeaponItem);
        }
        public bool TryGetWeapon(WeaponConfig itemConfig, out WeaponParamsHandler weaponParamsHandler)
        {
            weaponParamsHandler =
                _weaponsContainers.FirstOrDefault(handler => handler.Config == itemConfig);
            return weaponParamsHandler != null;
        }

        public void CreateNewWeapon(WeaponItemConfig itemConfig)
        {
            BaseWeapon weapon = Object.Instantiate(itemConfig.WeaponPrefab, _weaponRootTransform.transform);
            WeaponParamsHandler weaponParamsHandler = new WeaponParamsHandler(itemConfig.WeaponConfig, weapon, _playerStatsHolder);
            _weaponsContainers.Add(weaponParamsHandler);
        }
    }
}