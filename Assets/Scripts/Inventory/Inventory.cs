using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class Inventory : MonoBehaviour, IInventory
{
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;

    private List<InventorySlot> _slots = new List<InventorySlot>();
    private InventorySaveLoader _inventorySaveLoader;
    private ItemDatabase _itemDatabase;

    public UnityAction<ItemConfig> OnItemClick { get; set; }

    [Inject]
    private void Construct(InventorySaveLoader inventorySaveLoader, ItemDatabase itemDatabase)
    {
        _inventorySaveLoader = inventorySaveLoader;
        _itemDatabase = itemDatabase;
    }

    private async void Awake()
    {
        _saveButton.onClick.AddListener(SaveData);
        _loadButton.onClick.AddListener(LoadData);

        CreateSlots();
        LoadData();
    }

    private void OnDestroy()
    {
        _saveButton.onClick.RemoveListener(SaveData);
        _loadButton.onClick.RemoveListener(LoadData);
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

    private async void LoadData()
    {
        List<SerializableSlotsData> loadedSlots = await _inventorySaveLoader.LoadInventory();

        for (int i = 0; i < _slots.Count; i++)
        {
            if (i < loadedSlots.Count)
            {
                _slots[i].SetNewItem(_itemDatabase.GetItemConfigByType(loadedSlots[i].ItemType),
                    loadedSlots[i].ItemCount);
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
        if (slot != null)
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

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private async void SaveData()
    {
        await _inventorySaveLoader.SaveInventory(_slots);
    }
}