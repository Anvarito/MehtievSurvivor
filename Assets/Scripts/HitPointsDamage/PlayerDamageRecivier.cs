using Damage;
using UnityEngine.Events;

namespace HitPointsDamage
{
    public class PlayerDamageRecivier : DamageRecivier
    {
        public void ApplyDamage(float damage)
        {
            ApplyDamageInternal(damage);
        }
    }
}