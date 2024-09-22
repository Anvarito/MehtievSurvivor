using System;
using System.Collections;
using Damage;
using HitPointsDamage;
using Infrastructure.Extras;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyMove _enemyMove;
        [SerializeField] private EnemyAnimation _animator;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyDamageRecivier _enemyDamageRecivier;
        [SerializeField] private KnockSlide _knockSlide;
        [SerializeField] private Collider2D _collider;

        private IHitPoints _hitPointsHolder;
        public EnemyMove EnemyMove => _enemyMove;
        public EnemyAnimation Animator => _animator;
        public EnemyAttack EnemyAttack => _enemyAttack;
        public EnemyDamageRecivier EnemyDamageRecivier => _enemyDamageRecivier;
        public KnockSlide KnockSlide => _knockSlide;

        public void CreateEnemy(IHitPoints damage)
        {
            _hitPointsHolder = damage;
            _enemyDamageRecivier.OnKnock += TakeKnock;
        }
        
        private void TakeKnock(float power)
        {
            if (_hitPointsHolder.CurrentHitPoints.value <= 0)
            {
                _knockSlide.KnockFinal(100);
                _collider.enabled = false;
                _animator.DeadAnimation();
                print("DEAD " + gameObject.name);
            }
            else
            {
                _knockSlide.Knock(power);
            }
        }
    

        private void OnDestroy()
        {
            _enemyDamageRecivier.OnKnock -= TakeKnock;
        }
    }
}