using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "StatItemConfig", menuName = "Stats/StatItemData")]
    public class StatItemConfig : ItemConfig
    {
        public EStatType StatType;
        public int EffectAmount;
    }
}