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
        public BaseWeapon WeaponPrefab; 
    }

    public List<WeaponPrefabEntry> WeaponPrefabs;

    public BaseWeapon GetPrefabByWeaponName(WeaponConfig config)
    {
        var entry = WeaponPrefabs.Find(w => w.WeaponPrefab.Config == config);
        return entry?.WeaponPrefab;
    }
}