using UnityEngine.Events;

namespace Damage
{
    public class EnemyDamageRecivier : DamageRecivier
    {
        public UnityAction<float> OnKnock;
        public void ApplyKnockedDamage(float damage, float knockPower)
        {
            ApplyDamage(damage);
            OnKnock?.Invoke(knockPower);
        }
    }
}