using Damage;
using Enemies;
using Infrastructure.Extras;
using UnityEngine;
using Weapons.Configs;

namespace Weapons
{
    public class ThrowableWeapon : MonoBehaviour
    {
        [SerializeField] private TrowableWeaponDamageDealer _prefab;
        [SerializeField] private ThrowableWeaponConfig _weaponConfig;

        private MonobehPool<TrowableWeaponDamageDealer> _pool;
        private Camera _camera;
        
        private float _cooldown;

        private void Awake()
        {
            _camera = Camera.main;
            _pool = new MonobehPool<TrowableWeaponDamageDealer>(_prefab, 0);
        }

        private void Update()
        {
            if (Time.time > _cooldown)
            {
                Throw();
                _cooldown = Time.time + _weaponConfig.Cooldown;
            }
        }

        private void Throw()
        {
            Enemy nearbyEnemy = ScreenObjectFinder.FindNearestObjectOnScreen<Enemy>(_camera, transform, false);
            if (nearbyEnemy == null)
                return;

            bool isNew = _pool.Get(out TrowableWeaponDamageDealer throwable);
            throwable.transform.position = transform.position;
            throwable.gameObject.SetActive(true);

            throwable.Init(nearbyEnemy.transform.position, _weaponConfig.LifeTime, _weaponConfig.Speed);

            if (isNew)
            {
                throwable.OnLifeTimeOver += () => { ReleaseThrowable(throwable); };

                throwable.OnDamage += enemyDamageRecivier =>
                {
                    ReleaseThrowable(throwable);
                    HitToEnemy(enemyDamageRecivier);
                };
            }
        }

        private void ReleaseThrowable(TrowableWeaponDamageDealer trowable)
        {
            trowable.Dispose();
            _pool.Release(trowable);
        }

        private void HitToEnemy(EnemyDamageRecivier enemyDamage)
        {
            enemyDamage.ApplyDamage(_weaponConfig.DamageAmount, _weaponConfig.KnockAmount);
        }
    }
}