using System.Collections.Generic;
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
            // var item = _itemConfigs.FirstOrDefault(x => x.itemType == itemType);
            // return item;
            return null;
        }
    }
}