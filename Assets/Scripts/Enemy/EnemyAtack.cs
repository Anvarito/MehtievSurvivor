using HitPointsDamage;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        private float _damageAmount;
        private PlayerDamageRecivier _playerDamageRecivier;
        private float _attackInterval = 1f;
        private float _timeSinceLastAttack = 0f;
        public void Initial(float damageAmount, float attackInterval, PlayerDamageRecivier playerDamageRecivier)
        {
            _damageAmount = damageAmount;
            _playerDamageRecivier = playerDamageRecivier;
            _attackInterval = attackInterval;
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
            if (other.gameObject == _playerDamageRecivier.gameObject)
            {
                _timeSinceLastAttack = 0f;
            }
        }
    }
}