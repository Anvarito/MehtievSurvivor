using UnityEngine;

namespace Weapons.Configs
{
    [CreateAssetMenu(fileName = "New throwable weapon", menuName = "Weapons/Throwable weapon data")]
    public class ThrowableWeaponConfig : WeaponConfig
    {
        public float LifeTime = 1.5f;
        public float Speed = 1.5f;
    }
}