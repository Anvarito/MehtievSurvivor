using System;
using Damage;
using Infrastructure.Extras;
using UnityEngine;

namespace HitPointsDamage
{
    public class HitPointsHolder : IDisposable, IHitPoints
    {
        public ReactiveProperty<float> MaxHitPoints { get; private set; } = new();
        public ReactiveProperty<float> CurrentHitPoints { get; private set; } = new();
        
        private readonly DamageRecivier _damageRecivier;

        public HitPointsHolder(float hp, DamageRecivier damageRecivier)
        {
            _damageRecivier = damageRecivier;
            _damageRecivier.OnDamage += DecreaseHP;
            
            ResetHP(hp);
        }
        
        public void ResetHP(float hp)
        {
            MaxHitPoints.value = hp;
            CurrentHitPoints.SetWithoutNotification(MaxHitPoints.value);
        }
        
        public void IncreaseHP(float amount)
        {
            CurrentHitPoints.value = Mathf.Min(CurrentHitPoints.value + amount, MaxHitPoints.value);
        }

        public void DecreaseHP(float amount)
        {
            CurrentHitPoints.value = Mathf.Max(CurrentHitPoints.value - amount, 0);
        }

        public void Dispose()
        {
            _damageRecivier.OnDamage -= DecreaseHP;
        }
    }
}