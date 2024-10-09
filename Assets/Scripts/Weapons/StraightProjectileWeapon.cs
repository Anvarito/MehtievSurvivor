using UnityEngine;

namespace Weapons
{
    public class StraightProjectileWeapon : ProjectileWeapon<StraightShell>
    {
        
        protected override void InitProjectile(StraightShell straightShell)
        {
            straightShell.Init(transform.position + Vector3.up, _weaponParams.DamageAmount, _weaponParams.KnockAmount,_weaponParams.LifeTime, _weaponParams.Speed);
        }
    }
}