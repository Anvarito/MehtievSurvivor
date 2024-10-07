using Damage;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons
{
    public abstract class BaseProjectile : BaseShell
    {
        protected float _lifeTIme;
        protected float _speed;
        
        public UnityAction OnDestroy;
        
        public void Dispose()
        {
            transform.DOKill();
        }
        
        protected virtual void Update()
        {
            if (Time.time > _lifeTIme)
            {
                OnDestroy?.Invoke();
            }

            Move();
        }

        protected override void HitToEnemy(EnemyDamageRecivier enemyDamage)
        {
            enemyDamage.ApplyDamage(_damageAmount, _knockAmount);
        }

        protected abstract void Move();
    }
}