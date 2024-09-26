using Items;
using UnityEngine;

public class StatItem : PickableItem
{
    [SerializeField] private StatItemConfig _statItem;
    public StatItemConfig Config => _statItem;
    private void Start()
    {
        _renderer.sprite = _statItem.Image;
    }
    private void OnValidate()
    {
        if (_statItem)
            gameObject.name = _statItem.Name;
    }

    protected override void ApplyEffectInternal()
    {
        _itemEffectApplier.ApplyStatsUp(_statItem);
    }
}