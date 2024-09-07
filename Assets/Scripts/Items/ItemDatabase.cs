using System.Collections.Generic;
using System.Linq;
namespace Items
{
    public class ItemDatabase
    {
        private readonly HashSet<ItemConfig> _itemConfigs;

        public ItemDatabase(List<ItemConfig> itemConfigs)
        {
            _itemConfigs = new HashSet<ItemConfig>(itemConfigs);
        }

        public ItemConfig GetItemConfigByType(EItemType itemType)
        {
            var item = _itemConfigs.First(x => x.itemType == itemType);
            return item;
        }
    }
}