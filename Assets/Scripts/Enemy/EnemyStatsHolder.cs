using Infrastructure.Extras;

namespace Enemy
{
    public class EnemyStatsHolder : BaseStatsHolder
    {
        public ReactiveProperty<float> DamageAmount;
        public ReactiveProperty<float> AttackInterval;
    }
}