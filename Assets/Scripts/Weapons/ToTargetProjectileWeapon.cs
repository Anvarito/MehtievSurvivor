using Enemies;
using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public class ToTargetProjectileWeapon : ProjectileWeapon<StraightProjectile>
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

        protected override void InitProjectile(StraightProjectile straightProjectile)
        {
            straightProjectile.Init(_target.position, weaponUpgradeData.DamageAmount, weaponUpgradeData.KnockAmount,weaponUpgradeData.LifeTime, weaponUpgradeData.Speed);
        }
    }
}