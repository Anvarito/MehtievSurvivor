using UnityEngine;

namespace Weapons.Configs
{
    [CreateAssetMenu(fileName = "New weapon", menuName = "Weapons/Weapon data")]
    public class WeaponConfig : ScriptableObject
    {
        public string Name;
        public float DamageAmount;
        public float KnockAmount;
        public float Cooldown = 1.5f;
    }
}