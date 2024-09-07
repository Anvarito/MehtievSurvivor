using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour
{
    [SerializeField, HideInInspector] private List<InventorySlot> _slots = new List<InventorySlot>();
    private InventorySaveLoader _inventorySaveLoader;

    [Inject]
    private void Construct(InventorySaveLoader inventorySaveLoader)
    {
        _inventorySaveLoader = inventorySaveLoader;
    }
    
    private void Awake()
    {
        _slots.AddRange(GetComponentsInChildren<InventorySlot>());
        foreach (var slot in _slots)
        {
            slot.OnSlotClick += OnSlotClick;
        }

        List<InventorySlot> loadedSlots = _inventorySaveLoader.LoadInventory(); // Загрузка инвентаря
        InitSlots(loadedSlots); // Инициализация слотов
    }

    private void InitSlots(List<InventorySlot> loadedSlots)
    {
        loadedSlots = loadedSlots ?? new List<InventorySlot>();

        for (int i = 0; i < _slots.Count; i++)
        {
            if (i < loadedSlots.Count)
            {
                _slots[i].InitSlot(loadedSlots[i].ItemType, loadedSlots[i].ItemCount);
            }
            else
            {
                _slots[i].InitSlot(EItemType.None, 0);
            }
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
