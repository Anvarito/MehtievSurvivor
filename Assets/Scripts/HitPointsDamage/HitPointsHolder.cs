using System;
using Damage;
using Infrastructure.Extras;

namespace HitPointsDamage
{
    public class HitPointsHolder : IDisposable, IHitPoints
    {
        public float MaxHitPoints { get; private set; }
        public ReactiveProperty<float> CurrentHitPoints { get; private set; } = new ReactiveProperty<float>();
        
        private readonly DamageRecivier _damageRecivier;

        public HitPointsHolder(float hp, DamageRecivier damageRecivier)
        {
            MaxHitPoints = hp;
            _damageRecivier = damageRecivier;
            CurrentHitPoints.SetWithoutNotification(MaxHitPoints);
            
            _damageRecivier.OnDamage += ApplyDamage;
        }
        public void ApplyDamage(float amount)
        {
            CurrentHitPoints.value -= (int)amount;
        }

        public void Dispose()
        {
            _damageRecivier.OnDamage -= ApplyDamage;
        }
    }
}