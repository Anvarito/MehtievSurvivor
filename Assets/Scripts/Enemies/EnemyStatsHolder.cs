using System.Collections.Generic;
using Infrastructure.Extras;

namespace Enemies
{
    public class EnemyStatsHolder : BaseStatsHolder
    {
        public ReactiveProperty<float> DamageAmount;
        public ReactiveProperty<float> AttackInterval;
        public List<DropItem> DropItems;
    }
}