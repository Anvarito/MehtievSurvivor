using System;
using Damage;
using UnityEngine;

namespace HitPointsDamage
{
    public class DamageApplier : IDisposable
    {
        private readonly BaseStatsHolder _statsHolder;
        private readonly DamageRecivier _damageRecivier;

        public DamageApplier(BaseStatsHolder statsHolder, DamageRecivier damageRecivier)
        {
            _statsHolder = statsHolder;
                
            _damageRecivier = damageRecivier;
            _damageRecivier.OnDamage += TakeDamage;
        }

        private void TakeDamage(float damageAmount)
        {
            _statsHolder.CurrentHP.value = Mathf.Max(_statsHolder.CurrentHP.value - damageAmount, 0);
        }

        public void Dispose()
        {
            _damageRecivier.OnDamage -= TakeDamage;
        }
    }
}