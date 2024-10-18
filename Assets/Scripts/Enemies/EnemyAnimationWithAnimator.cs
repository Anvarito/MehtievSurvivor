using UnityEngine;

namespace Enemies
{
    public class EnemyAnimationWithAnimator : EnemyAnimation
    {
        [SerializeField] private EnemyAttackDealer enemyAttackDealer;
        [SerializeField] private Animator _animator;
        private readonly int _attack = Animator.StringToHash("Attack");

        protected override void Awake()
        {
            base.Awake();
            enemyAttackDealer.OnAttack += AttackAnim;
        }
        private void AttackAnim()
        {
            if (_animator != null)
                _animator.SetTrigger(_attack);
        }
    }
}