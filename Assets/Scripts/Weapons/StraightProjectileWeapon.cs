using UnityEngine;

namespace Weapons
{
    public class StraightProjectileWeapon : ProjectileWeapon<StraightProjectile>
    {
        
        protected override void InitProjectile(StraightProjectile straightProjectile)
        {
            straightProjectile.Init(transform.position + Vector3.up, _weaponParams.DamageAmount, _weaponParams.KnockAmount,_weaponParams.LifeTime, _weaponParams.Speed);
        }
    }
}