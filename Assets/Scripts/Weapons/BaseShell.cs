using Damage;
using UnityEngine;

namespace Weapons
{
    public abstract class BaseShell : MonoBehaviour
    {
        [SerializeField] protected DamageDealer damageDealer;

        protected float _damageAmount;
        protected float _knockAmount;
        private void Awake()
        {
            damageDealer.OnDamage += HitToEnemy;
        }

        private void OnDestroy()
        {
            damageDealer.OnDamage -= HitToEnemy;
        }

        protected virtual void HitToEnemy(EnemyDamageRecivier enemyDamage)
        {
            
        }
    }
}