using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Configs
{
    [CreateAssetMenu(fileName = "New weapon", menuName = "Weapons/Weapon data")]
    public class WeaponConfig : ScriptableObject
    {
        public string Name;
        public List<WeaponUpgradeData> weaponUpgradeDatas;
    }

    [Serializable]
    public class WeaponUpgradeData
    {
        public float DamageAmount;
        public float KnockAmount;
        public float Cooldown;
        public float LifeTime;
        public float Speed;
    }
}