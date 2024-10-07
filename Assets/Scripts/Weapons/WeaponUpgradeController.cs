using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Weapons;
using Weapons.Configs;
using Zenject;

public class WeaponUpgradeController : IInitializable
{
    private readonly WeaponRootTransform _weaponRootTransform;
    private readonly WeaponPrefabHolder _prefabHolder;
    private List<BaseWeapon> _baseLaunchers = new();

    public WeaponUpgradeController(WeaponRootTransform weaponRootTransform, WeaponPrefabHolder prefabHolder)
    {
        _weaponRootTransform = weaponRootTransform;
        _prefabHolder = prefabHolder;
    }

    public void Initialize()
    {
        _baseLaunchers.AddRange(_weaponRootTransform.GetComponentsInChildren<BaseWeapon>());
    }

    public void ApplyWeapon(WeaponConfig config)
    {
        BaseWeapon weapon = _baseLaunchers.FirstOrDefault(l => l.Config == config);

        if (weapon != null)
        {
            weapon.EncreaseLevelWeapon();
        }
        else
        {
            CreateNewLauncher(config);
        }
    }

    private void CreateNewLauncher(WeaponConfig config)
    {
        BaseWeapon weaponPrefab = _prefabHolder.GetPrefabByWeaponName(config);

        if (weaponPrefab != null)
        {
            BaseWeapon newWeapon = Object.Instantiate(weaponPrefab, _weaponRootTransform.transform);
            _baseLaunchers.Add(newWeapon);
        }
        else
        {
            Debug.LogError($"No prefab found for weapon: {config.Name}");
        }
    }
}