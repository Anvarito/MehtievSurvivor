using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Inventory : MonoBehaviour
{
    private List<InventorySlot> _slots = new List<InventorySlot>();
    private InventorySaveLoader _inventorySaveLoader;
    private ItemDatabase _itemDatabase;

    public UnityAction<ItemConfig> OnItemClick;

    [Inject]
    private void Construct(InventorySaveLoader inventorySaveLoader, ItemDatabase itemDatabase)
    {
        _inventorySaveLoader = inventorySaveLoader;
        _itemDatabase = itemDatabase;
    }
    
    private void Awake()
    {
        CreateSlots();
        LoadSlotsData();
    }

    private void CreateSlots()
    {
        var slotViews = GetComponentsInChildren<InventorySlotView>(true);
        for (int i = 0; i < slotViews.Length; i++)
        {
            InventorySlot inventorySlot = new InventorySlot(slotViews[i]);
            _slots.Add(inventorySlot);
            inventorySlot.OnSlotClick += ItemClick;
        }
    }

    private void LoadSlotsData()
    {
        List<SerializableSlotsData> loadedSlots = _inventorySaveLoader.LoadInventory();

        for (int i = 0; i < _slots.Count; i++)
        {
            if (i < loadedSlots.Count)
            {
                _slots[i].SetNewItem(_itemDatabase.GetItemConfigByType(loadedSlots[i].ItemType), loadedSlots[i].ItemCount);
            }
            else
            {
                _slots[i].SetNewItem(null, 0);
            }
        }
    }

    public void AddItem(ItemConfig itemConfig)
    {
        var slot = _slots.FirstOrDefault(x => x.ItemType == itemConfig.itemType);
        if(slot != null)
            slot.EncreaseItem();
        else
        {
            slot = _slots.FirstOrDefault(x => x.ItemType == EItemType.None);
            slot.SetNewItem(itemConfig, 1);
        }
    }

    private void ItemClick(InventorySlot slot)
    {
        OnItemClick?.Invoke(_itemDatabase.GetItemConfigByType(slot.ItemType));
    }

    private void OnDestroy()
    {
        _inventorySaveLoader.SaveInventory(_slots);
    }
}

