using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "StatItem", menuName = "Stats/StatItemData")]
    public class StatItem : ItemConfig
    {
        public EStatType StatType;
        public int EffectAmount;
    }
}