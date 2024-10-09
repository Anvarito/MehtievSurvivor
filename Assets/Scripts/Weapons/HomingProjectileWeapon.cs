using Enemies;
using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public class HomingProjectileWeapon : ProjectileWeapon<HomingProjectile>
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

        protected override void InitProjectile(HomingProjectile homingProjectile)
        {
            homingProjectile.Init(_target, _weaponParams.DamageAmount, _weaponParams.KnockAmount, _weaponParams.LifeTime, _weaponParams.Speed);
        }
    }
}