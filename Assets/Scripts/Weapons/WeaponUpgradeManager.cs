using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;
using Weapons.Configs;
using Zenject;

namespace Weapons
{
    public class WeaponUpgradeManager : IInitializable, IWeaponUpgrader
    {
        private readonly WeaponRootTransform _weaponRootTransform;
        private readonly PlayerStatsHolder _playerStatsHolder;
        private readonly WeaponItemConfig _defaultWeaponItem;
        private List<WeaponParamsHandler> _weaponsContainers = new();
        public WeaponUpgradeManager(WeaponRootTransform weaponRootTransform,
            PlayerStatsHolder playerStatsHolder, WeaponItemConfig defaultWeaponItem)
        {
            _weaponRootTransform = weaponRootTransform;
            _playerStatsHolder = playerStatsHolder;
            _defaultWeaponItem = defaultWeaponItem;
        }
        public void Initialize()
        {
            CreateNewWeapon(_defaultWeaponItem);
        }
        public void UpdateWeapon(WeaponItemConfig itemConfig)
        {
            WeaponParamsHandler paramsHandler = _weaponsContainers.FirstOrDefault(l => l.Config == itemConfig.WeaponConfig);
        
            if (paramsHandler != null)
            {
                paramsHandler.ChangeTier();
            }
            else
            {
                CreateNewWeapon(itemConfig);
            }
        }
        private void CreateNewWeapon(WeaponItemConfig itemConfig)
        {
            BaseWeapon weapon = Object.Instantiate(itemConfig.WeaponPrefab, _weaponRootTransform.transform);
            CreateNewContainer(itemConfig.WeaponConfig, weapon);
        }

        private void CreateNewContainer(WeaponConfig config, BaseWeapon weapon)
        {
            WeaponParamsHandler weaponParamsHandler = new WeaponParamsHandler(config, weapon, _playerStatsHolder);
            _weaponsContainers.Add(weaponParamsHandler);
        }
    }
}