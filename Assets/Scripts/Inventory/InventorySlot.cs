using System;
using Items;
using UnityEngine.Events;

public class InventorySlot
{
    private InventorySlotView _inventorySlotView;
    public UnityAction<InventorySlot> OnSlotClick;
    public int ItemCount { get; private set; }
    public EItemType ItemType { get; private set; }

    public InventorySlot(InventorySlotView inventorySlotView)
    {
        _inventorySlotView = inventorySlotView;
        _inventorySlotView.OnClick += ButtonClick;
    }

    public void SetNewItem(ItemConfig itemConfig, int count)
    {
        if (itemConfig)
        {
            ItemCount = count;
            ItemType = itemConfig.itemType;

            _inventorySlotView.SetCount(ItemCount);
            _inventorySlotView.SetImage(itemConfig.Image);
        }
        else
        {
            _inventorySlotView.SetCount(0);
        }
    }

    private void ButtonClick()
    {
        OnSlotClick?.Invoke(this);
    }

    public void EncreaseItem()
    {
        ItemCount++;
        _inventorySlotView.SetCount(ItemCount);
    }

    public void DecreaseItem()
    {
        if (ItemCount <= 0)
            return;
        
        ItemCount--;
        _inventorySlotView.SetCount(ItemCount);

        if (ItemCount == 0)
            ItemType = EItemType.None;
    }

    public SerializableSlotsData ToSerializable()
    {
        return new SerializableSlotsData
        {
            ItemCount = ItemCount,
            ItemType = ItemType
        };
    }
}

[Serializable]
public class SerializableSlotsData
{
    public int ItemCount;
    public EItemType ItemType;
}