using System.Collections.Generic;
using Items;

namespace Player.PlayerStats
{
    public class EffectContainer : IEffectContainer
    {
        private readonly ItemPanel _itemPanel;
        private HashSet<EStatType> _itemConfigs;

        public EffectContainer(ItemPanel itemPanel)
        {
            _itemPanel = itemPanel;
            _itemConfigs = new HashSet<EStatType>();
        }

        public void AddStatItem(StatItemConfig itemConfig)
        {
            _itemConfigs.Add(itemConfig.StatType);
            _itemPanel.SetNewEffect(itemConfig);
        }

        public bool CheckEffect(EStatType statType)
        {
            return _itemConfigs.Contains(statType);
        }
    }
}