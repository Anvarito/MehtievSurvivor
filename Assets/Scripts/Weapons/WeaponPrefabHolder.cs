using System.Collections.Generic;
using UnityEngine;
using Weapons;
using Weapons.Configs;

[CreateAssetMenu(fileName = "NewPrefabFactory", menuName = "Weapons/Prefab Factory")]
public class WeaponPrefabHolder : ScriptableObject
{
    [System.Serializable]
    public class WeaponPrefabEntry
    {
        public WeaponConfig WeaponConfig;
        public BaseWeapon WeaponPrefab;
    }

    public List<WeaponPrefabEntry> WeaponPrefabs;

    public BaseWeapon GetWeaponByConfig(WeaponConfig config)
    {
        var entry = WeaponPrefabs.Find(w => w.WeaponConfig == config);
        return entry?.WeaponPrefab;
    }

    public WeaponConfig GetConfigByWeapon(BaseWeapon weapon)
    {
        var entry = WeaponPrefabs.Find(w => w.WeaponPrefab.gameObject.name == weapon.gameObject.name);
        if (entry != null)
            return entry.WeaponConfig;
        Debug.Log($"{weapon.gameObject.name} not exist!");
        return null;
    }
}