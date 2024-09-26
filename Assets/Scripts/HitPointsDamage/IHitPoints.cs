using Infrastructure.Extras;

namespace HitPointsDamage
{
    public interface IHitPoints
    {
        public ReactiveProperty<float> CurrentHitPoints { get; }
        public ReactiveProperty<float> MaxHitPoints { get; }
        public void IncreaseHP(float amount);
        public void DecreaseHP(float amount);
        public void ResetHP(float hp);
    }
}