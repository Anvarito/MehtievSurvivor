using Damage;
using UnityEngine;

namespace Weapons
{
    public class StraightProjectile : BaseProjectile
    {
        protected Vector3 _direction;

        public virtual void Init(Vector3 target, float damageAmount,float knockAmount, float lifeTime,float speed)
        {
            _damageAmount = damageAmount;
            _knockAmount = knockAmount;
            _lifeTIme = Time.time + lifeTime;
            _speed = speed;
            
            _direction = (target - transform.position).normalized;
        }

        protected override void Move()
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        }

        protected override void HitToEnemy(EnemyDamageRecivier enemyDamage)
        {
            base.HitToEnemy(enemyDamage);
            OnDestroy?.Invoke();
        }
    }
}