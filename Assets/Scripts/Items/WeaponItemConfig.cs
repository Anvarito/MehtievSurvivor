using UnityEngine;
using UnityEngine.Serialization;
using Weapons.Configs;

namespace Items
{
    [CreateAssetMenu(fileName = "WeaponItemConfig", menuName = "Weapons/WeaponItemData")]
    public class WeaponItemConfig : ItemConfig
    {
        [FormerlySerializedAs("meleeWeaponConfig")] public WeaponConfig WeaponConfig;
    }
}