using Items;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemConfig _itemConfig;

    public ItemConfig ItemConfig => _itemConfig;

    private void OnValidate()
    {
        if (_itemConfig)
            gameObject.name = _itemConfig.Name;
    }
}