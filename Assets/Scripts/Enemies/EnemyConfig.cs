using System.Collections.Generic;
using Configs.Items;
using Infrastructure.Extras;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Enemy configs/EnemyConfig", order = 1)]
    public class EnemyConfig : DefaultUnitConfig
    {
        public float DamageAmount = 1;
        public float AttackInterval = 1;
        public List<DropItem> DropItems;
        public EnemyStatsHolder GetEnemyData()
        {
            return new EnemyStatsHolder
            {
                MaxHP = new ReactiveProperty<float>(MaxHP),
                CurrentHP = new ReactiveProperty<float>(MaxHP),
                Speed = new ReactiveProperty<float>(MoveSpeed),
                DamageAmount = new ReactiveProperty<float>(DamageAmount),
                AttackInterval = new ReactiveProperty<float>(AttackInterval),
                DropItems = new List<DropItem>(DropItems)
            };
        }

        public void ResetParams(EnemyStatsHolder enemyStatsHolder)
        {
            enemyStatsHolder.MaxHP.SetWithoutNotification(MaxHP);
            enemyStatsHolder.CurrentHP.SetWithoutNotification(MaxHP);
            enemyStatsHolder.Speed.SetWithoutNotification(MoveSpeed);
            enemyStatsHolder.DamageAmount.SetWithoutNotification(DamageAmount);
            enemyStatsHolder.AttackInterval.SetWithoutNotification(AttackInterval);
            enemyStatsHolder.DropItems = DropItems;
        }
    }

    [System.Serializable]
    public class DropItem
    {
        public ExpData expConfig;  
        [Range(0, 100)]
        public float dropChance;
    }
}