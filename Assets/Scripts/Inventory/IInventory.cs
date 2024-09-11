using Items;
using UnityEngine.Events;

public interface IInventory{

    public UnityAction<ItemConfig> OnItemClick { get; set; }
    public void AddItem(ItemConfig itemConfig);
}