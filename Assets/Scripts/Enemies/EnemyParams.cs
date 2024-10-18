using System.Collections.Generic;
using Infrastructure.Extras;

namespace Enemies
{
    public class EnemyParams : BaseStatsHolder
    {
        public ReactiveProperty<float> DamageAmount { get; set; }
        public ReactiveProperty<float> AttackInterval { get; set; }
        public List<DropItem> DropItems { get; set; }
    }
}