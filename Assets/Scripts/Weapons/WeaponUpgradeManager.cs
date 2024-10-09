using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Weapons.Configs;
using Zenject;

namespace Weapons
{
    public class WeaponUpgradeManager : IInitializable, IWeaponUpgrader
    {
        private readonly WeaponRootTransform _weaponRootTransform;
        private readonly WeaponPrefabHolder _prefabHolder;
        private readonly PlayerStatsHolder _playerStatsHolder;
        private List<WeaponParamsHandler> _weaponsContainers = new();
        public WeaponUpgradeManager(WeaponRootTransform weaponRootTransform, WeaponPrefabHolder prefabHolder,
            PlayerStatsHolder playerStatsHolder)
        {
            _weaponRootTransform = weaponRootTransform;
            _prefabHolder = prefabHolder;
            _playerStatsHolder = playerStatsHolder;
        }
        public void Initialize()
        {
            var weapons = _weaponRootTransform.GetComponentsInChildren<BaseWeapon>();
            foreach (var weapon in weapons)
            {
                CreateNewContainer(_prefabHolder.GetConfigByWeapon(weapon), weapon);
            }
        }
        public void UpdateWeapon(WeaponConfig config)
        {
            WeaponParamsHandler paramsHandler = _weaponsContainers.FirstOrDefault(l => l.Config == config);
        
            if (paramsHandler != null)
            {
                paramsHandler.ChangeTier();
            }
            else
            {
                CreateNewWeapon(config);
            }
        }
        private void CreateNewWeapon(WeaponConfig config)
        {
            BaseWeapon prefab = _prefabHolder.GetWeaponByConfig(config);
            BaseWeapon weapon = Object.Instantiate(prefab, _weaponRootTransform.transform);
            CreateNewContainer(config, weapon);
        }

        private void CreateNewContainer(WeaponConfig config, BaseWeapon weapon)
        {
            WeaponParamsHandler weaponParamsHandler = new WeaponParamsHandler(config, weapon, _playerStatsHolder);
            _weaponsContainers.Add(weaponParamsHandler);
        }
    }
}