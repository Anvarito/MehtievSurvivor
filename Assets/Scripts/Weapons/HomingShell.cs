using Damage;
using UnityEngine;

namespace Weapons
{
    public class HomingShell : BaseShell
    {
        private Transform _target;

        public void Init(Transform target, float damageAmount,float knockAmount, float lifeTime,float speed)
        {
            _target = target;
            _lifeTIme = Time.time + lifeTime;
            _speed = speed;
            _damageAmount = damageAmount;
            _knockAmount = knockAmount;
        }
        
        protected override void Move()
        {
            var direction = (_target.position - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        }
        
        protected override void HitToEnemy(EnemyDamageRecivier enemyDamage)
        {
            base.HitToEnemy(enemyDamage);
            OnShellDestroy?.Invoke();
        }
    }
}