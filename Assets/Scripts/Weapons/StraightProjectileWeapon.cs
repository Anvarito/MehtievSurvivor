using UnityEngine;

namespace Weapons
{
    public class StraightProjectileWeapon : ProjectileWeapon<StraightProjectile>
    {
        
        protected override void InitProjectile(StraightProjectile straightProjectile)
        {
            straightProjectile.Init(transform.position + Vector3.up, weaponUpgradeData.DamageAmount, weaponUpgradeData.KnockAmount,weaponUpgradeData.LifeTime, weaponUpgradeData.Speed);
        }
    }
}