using HitPointsDamage;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        private EnemyStatsHolder _statsHolder;
        private PlayerDamageRecivier _playerDamageRecivier;
        
        private float _damageAmount;
        private float _attackInterval = 1f;
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
                _playerDamageRecivier.ApplyDamage(_damageAmount);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject == _playerDamageRecivier.gameObject)
            {
                _timeSinceLastAttack += Time.deltaTime;

                if (_timeSinceLastAttack >= _attackInterval)
                {
                    _playerDamageRecivier.ApplyDamage(_damageAmount);
                    _timeSinceLastAttack = 0f;
                }
            }
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