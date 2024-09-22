using UnityEngine.Events;

namespace Damage
{
    public class EnemyDamageRecivier : DamageRecivier
    {
        public UnityAction<float> OnKnock;
        public void ApplyDamage(float damage, float knockPower)
        {
            ApplyDamageInternal(damage);
            OnKnock?.Invoke(knockPower);
        }
    }
}