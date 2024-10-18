using System.Collections.Generic;
using Configs.Items;
using Infrastructure.Extras;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Enemy configs/EnemyConfig", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        public Enemy Prefab;
        public float MaxHP = 100;
        public float MoveSpeed = 10;
        public float DamageAmount = 1;
        public float AttackInterval = 1;
        
        [Space(20)] public List<DropItem> DropItems;
        public EnemyParams EnemyParams { get; private set; }
        public EnemyParams GetNewParams()
        {
            EnemyParams = new EnemyParams()
            {
                MaxHP = new ReactiveProperty<float>(MaxHP),
                CurrentHP = new ReactiveProperty<float>(MaxHP),
                Speed = new ReactiveProperty<float>(MoveSpeed),
                DamageAmount = new ReactiveProperty<float>(DamageAmount),
                AttackInterval = new ReactiveProperty<float>(AttackInterval),
                DropItems = new List<DropItem>(DropItems),
            };

            return EnemyParams;
        }
    }

    [System.Serializable]
    public class DropItem
    {
        public ExpData expConfig;
        [Range(0, 100)] public float dropChance;
    }
}