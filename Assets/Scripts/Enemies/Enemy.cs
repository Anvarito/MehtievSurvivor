using Damage;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _view;
        [SerializeField] private EnemyMove _enemyMove;
        [SerializeField] private EnemyAnimation _animator;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyDamageRecivier _enemyDamageRecivier;
        [SerializeField] private KnockSlide _knockSlide;
        [SerializeField] private Collider2D _collider;
        
        private EnemyStatsHolder _statsHolder;
        public EnemyStatsHolder StatsHolder => _statsHolder;
        public EnemyMove EnemyMove => _enemyMove;
        public EnemyAnimation Animator => _animator;
        public EnemyAttack EnemyAttack => _enemyAttack;
        public EnemyDamageRecivier EnemyDamageRecivier => _enemyDamageRecivier;
        public KnockSlide KnockSlide => _knockSlide;

        public UnityAction<Enemy> OnDead;

        private void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy");
        }

        public void CreateEnemy(EnemyStatsHolder statsHolder, Sprite sprite)
        {
            _statsHolder = statsHolder;
            _enemyDamageRecivier.OnKnock += TakeKnock;
            _view.sprite = sprite;
        }

        private void TakeKnock(float power)
        {
            if (_statsHolder.CurrentHP.value <= 0)
            {
                _enemyMove.enabled = false;
                _knockSlide.KnockFinal(100);
                _enemyDamageRecivier.enabled = false;
                _collider.enabled = false;
                _animator.DeadAnimation(1, () =>
                {
                    OnDead?.Invoke(this);
                });
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