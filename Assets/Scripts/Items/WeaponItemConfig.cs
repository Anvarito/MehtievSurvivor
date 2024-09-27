using UnityEngine;
using Weapons.Configs;

namespace Items
{
    [CreateAssetMenu(fileName = "WeaponItemConfig", menuName = "Weapons/WeaponItemData")]
    public class WeaponItemConfig : ItemConfig
    {
        public WeaponConfig WeaponConfig;
    }
}