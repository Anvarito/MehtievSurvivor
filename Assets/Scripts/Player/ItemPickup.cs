using UnityEngine;
using Zenject;

public class ItemPickup : MonoBehaviour
{
    private IInventory _inventory;

    [Inject]
    private void Construct(IInventory inventory)
    {
        _inventory = inventory;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Item item))
        {
            _inventory.AddItem(item.ItemConfig);
            Destroy(item.gameObject);
        }
    }
}
