using HitPointsDamage;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        private EnemyStatsHolder _statsHolder;
        private PlayerDamageRecivier _playerDamageRecivier;

        private float _damageAmount;
        private float _attackInterval;
        private float _timeSinceLastAttack = 0f;


        public void Initial(EnemyStatsHolder statsHolder, PlayerDamageRecivier playerDamageRecivier)
        {
            _statsHolder = statsHolder;
            _playerDamageRecivier = playerDamageRecivier;
            _attackInterval = _statsHolder.AttackInterval.value;
            _damageAmount = _statsHolder.DamageAmount.value;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject == _playerDamageRecivier.gameObject)
            {
                Attack();
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject == _playerDamageRecivier.gameObject)
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
            _playerDamageRecivier.ApplyDamage(_damageAmount);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (_playerDamageRecivier != null && other.gameObject == _playerDamageRecivier.gameObject)
            {
                _timeSinceLastAttack = 0f;
            }
        }
    }
}