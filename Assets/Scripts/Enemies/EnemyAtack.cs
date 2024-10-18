using Damage;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class EnemyAttackDealer : MonoBehaviour
    {
        private EnemyParams _params;
        private DamageRecivier _targetDamageRecivier;

        private float _damageAmount;
        private float _attackInterval;
        private float _timeSinceLastAttack = 0f;

        public UnityAction OnAttack;
        public void SetDependencies(EnemyParams enemyParams, DamageRecivier targetDamageRecivier)
        {
            _params = enemyParams;
            _targetDamageRecivier = targetDamageRecivier;
            _attackInterval = _params.AttackInterval.value;
            _damageAmount = _params.DamageAmount.value;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject == _targetDamageRecivier.gameObject)
            {
                Attack();
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject == _targetDamageRecivier.gameObject)
            {
                if (Time.time >= _timeSinceLastAttack)
                {
                    Attack();
                    _timeSinceLastAttack = Time.time + _attackInterval;
                }
            }
        }

        protected virtual void Attack()
        {
            _targetDamageRecivier.ApplyDamage(_damageAmount);
            OnAttack?.Invoke();
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (_targetDamageRecivier != null && other.gameObject == _targetDamageRecivier.gameObject)
            {
                _timeSinceLastAttack = 0f;
            }
        }
    }
}