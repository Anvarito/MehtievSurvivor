using Damage;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons
{
    public abstract class BaseShell : MonoBehaviour
    {
        [SerializeField] protected DamageDealer damageDealer;
        
        protected float _lifeTIme;
        protected float _speed;
        protected float _damageAmount;
        protected float _knockAmount;
        
        public UnityAction OnShellDestroy;
        
        private void Awake()
        {
            damageDealer.OnDamage += HitToEnemy;
        }

        private void OnDestroy()
        {
            damageDealer.OnDamage -= HitToEnemy;
        }
        public void Dispose()
        {
            transform.DOKill();
        }
        
        protected virtual void Update()
        {
            if (Time.time > _lifeTIme)
            {
                OnShellDestroy?.Invoke();
            }

            Move();
        }
       
        protected virtual void HitToEnemy(EnemyDamageRecivier enemyDamage)
        {
            enemyDamage.ApplyDamage(_damageAmount, _knockAmount);
        }

        protected abstract void Move();
    }
}