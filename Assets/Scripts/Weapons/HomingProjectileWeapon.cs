using Damage;
using Enemies;
using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public class HomingProjectileWeapon : ProjectileWeapon<HomingShell>
    {
        private Transform _target;

        protected virtual Transform FindTarget()
        {
            var nearbyTarget = ScreenObjectFinder.FindNearestObjectOnScreen<EnemyDamageRecivier>(_camera, transform, false);
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

        protected override void InitProjectile(HomingShell homingShell)
        {
            homingShell.Init(_target, _weaponParams.DamageAmount, _weaponParams.KnockAmount, _weaponParams.LifeTime, _weaponParams.Speed);
        }
    }
}