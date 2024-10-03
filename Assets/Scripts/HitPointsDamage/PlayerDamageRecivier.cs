using System;
using Damage;

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