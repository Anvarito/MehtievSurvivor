using HitPointsDamage;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public float DamageAmount { get; set; }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerDamageRecivier playerDamageRecivier))
            {
                playerDamageRecivier.ApplyDamage(DamageAmount);
            }
        }
    }
}