using System;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerDamageRecivier playerDamageRecivier))
            {
                playerDamageRecivier.ApplyDamage(_enemyConfig.AttackAmount);
            }
        }
    }
}