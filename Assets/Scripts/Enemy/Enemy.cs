using Damage;
using HitPointsDamage;
using UnityEngine;
using UnityEngine.Events;

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
        public IHitPoints HitPoints => _hitPointsHolder;
        public EnemyMove EnemyMove => _enemyMove;
        public EnemyAnimation Animator => _animator;
        public EnemyAttack EnemyAttack => _enemyAttack;
        public EnemyDamageRecivier EnemyDamageRecivier => _enemyDamageRecivier;
        public KnockSlide KnockSlide => _knockSlide;
        
        public UnityAction<Enemy> OnDead;

        public void CreateEnemy(IHitPoints hpHolder)
        {
            _hitPointsHolder = hpHolder;
            _enemyDamageRecivier.OnKnock += TakeKnock;
        }

        private void TakeKnock(float power)
        {
            if (_hitPointsHolder.CurrentHitPoints.value <= 0)
            {
                _knockSlide.KnockFinal(100);
                _enemyDamageRecivier.enabled = false;
                _collider.enabled = false;
                _animator.DeadAnimation(1, () => { OnDead?.Invoke(this); });
            }
            else
            {
                _knockSlide.Knock(power);
                _animator.HitAnimation();
            }
        }

        public void Reset()
        {
            _collider.enabled = true;
            _enemyMove.enabled = true;
            _animator.Reset();
        }

        private void OnDestroy()
        {
            _enemyDamageRecivier.OnKnock -= TakeKnock;
        }
    }
}