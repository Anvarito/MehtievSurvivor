using UnityEngine;
using Weapons.Configs;

namespace Items
{
    [CreateAssetMenu(fileName = "WeaponItem", menuName = "Weapons/WeaponItemData")]
    public class WeaponItem : ItemConfig
    {
        public WeaponConfig WeaponConfig;
    }
}