using System.Collections.Generic;
using Damage;
using HitPointsDamage;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyMove _enemyMove;
        [SerializeField] private EnemyAnimation _animator;
        [SerializeField] private EnemyAttackDealer enemyAttackDealer;
        [SerializeField] private EnemyDamageRecivier _enemyDamageRecivier;
        [SerializeField] private KnockSlide _knockSlide;
        [SerializeField] private Collider2D _collider;

        public UnityAction<Enemy> OnDead;
        private Transform _target;
        private EnemyParams _params;
        public List<DropItem> DropItems => _params.DropItems;
        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy");
        }

        public void Initialize(EnemyParams enemyParams, Transform target,
            PlayerDamageRecivier playerDamageRecivier)
        {
            _target = target;
            _params = enemyParams;
            _params.CurrentHP.Changed += HitPointsChanged;
            var damageApplier = new DamageApplier(enemyParams, _enemyDamageRecivier);
            _enemyMove.SetDependencies(_target, enemyParams);
            _animator.SetDependencies(_target, enemyParams);
            _knockSlide.SetDependencies(_target, enemyParams);
            enemyAttackDealer.SetDependencies(enemyParams, playerDamageRecivier);
            
            _animator.OnDieAnimationEnd += Die;
        }

        private void Die()
        {
            OnDead?.Invoke(this);
        }

        private void HitPointsChanged(float updateHP)
        {
            if (updateHP <= 0)
            {
                _enemyMove.enabled = false;
                _enemyDamageRecivier.enabled = false;
                _collider.enabled = false;
            }
        }


        public void Revive(EnemyParams enemyParams)
        {
            _params = enemyParams;
            _collider.enabled = true;
            _enemyMove.enabled = true;
            _enemyDamageRecivier.enabled = true;
        }

        private void OnDestroy()
        {
            _params.CurrentHP.Changed -= HitPointsChanged;
        }
    }
}