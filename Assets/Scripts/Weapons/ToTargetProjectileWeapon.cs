using Enemies;
using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public class ToTargetProjectileWeapon : ProjectileWeapon<StraightShell>
    {
        private Transform _target;

        protected virtual Transform FindTarget()
        {
            Enemy nearbyTarget = ScreenObjectFinder.FindNearestObjectOnScreen<Enemy>(_camera, transform, false);
            if (nearbyTarget)
                return nearbyTarget.transform;

            return null;
        }

        protected override void Launch()
        {
            _target = FindTarget();
            if (_target != null)
            {
                base.Launch();
                _target = null;
            }
        }

        protected override void InitProjectile(StraightShell straightShell)
        {
            straightShell.Init(_target.position, _weaponParams.DamageAmount, _weaponParams.KnockAmount,_weaponParams.LifeTime, _weaponParams.Speed);
        }
    }
}