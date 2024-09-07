using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour
{
    [SerializeField, HideInInspector] private List<InventorySlot> _slots = new List<InventorySlot>();
    private InventorySaveLoader _inventorySaveLoader;
    private ItemDatabase _itemDatabase;

    [Inject]
    private void Construct(InventorySaveLoader inventorySaveLoader, ItemDatabase itemDatabase)
    {
        _inventorySaveLoader = inventorySaveLoader;
        _itemDatabase = itemDatabase;
    }
    
    private void Awake()
    {
        _slots.AddRange(GetComponentsInChildren<InventorySlot>());
        foreach (var slot in _slots)
        {
            slot.OnSlotClick += OnSlotClick;
        }

        List<InventorySlot> loadedSlots = _inventorySaveLoader.LoadInventory();
        LoadSlots(loadedSlots);
    }

    private void LoadSlots(List<InventorySlot> loadedSlots)
    {
        loadedSlots = loadedSlots ?? new List<InventorySlot>();

        for (int i = 0; i < _slots.Count; i++)
        {
            if (i < loadedSlots.Count)
            {
                _slots[i].InitSlot(_itemDatabase.GetItemConfigByType(loadedSlots[i].ItemType), loadedSlots[i].ItemCount);
            }
            else
            {
                _slots[i].InitSlot(null, 0);
            }
        }
    }

    public void AddItem(ItemConfig itemConfig)
    {
        var slot = _slots.FirstOrDefault(x => x.ItemType == itemConfig.itemType);
        if(slot)
            slot.EncreaseItem();
        else
        {
            slot = _slots.FirstOrDefault(x => x.ItemType == EItemType.None);
            slot.InitSlot(itemConfig, 1);
        }
    }

    private void OnSlotClick(InventorySlot slot)
    {
        print(slot.ItemType + " " + slot.ItemCount);
    }

    private void OnDestroy()
    {
        _inventorySaveLoader.SaveInventory(_slots);
    }
}
