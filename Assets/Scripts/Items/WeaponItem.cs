using Items;
using UnityEngine;

public class WeaponItem : PickableItem
{
    [SerializeField] private WeaponItemConfig _weaponItem;
    public WeaponItemConfig Config => _weaponItem;

    private void Start()
    {
        _renderer.sprite = _weaponItem.Image;
    }

    private void OnValidate()
    {
        if (_weaponItem)
            gameObject.name = _weaponItem.Name;
    }
    
    protected override void ApplyEffect()
    {
        _itemApplier.ApplyWeaponItem(_weaponItem);
        Destroy(gameObject);
    }
}