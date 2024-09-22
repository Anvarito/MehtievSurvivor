using Infrastructure.Extras;

namespace HitPointsDamage
{
    public interface IHitPoints
    {
        public ReactiveProperty<float> CurrentHitPoints { get; }
        public float MaxHitPoints { get; }
        public void ApplyDamage(float amount);
    }
}