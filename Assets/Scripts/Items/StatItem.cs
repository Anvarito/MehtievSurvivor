using Items;
using UnityEngine;

public class StatItem : PickableItem
{
    [SerializeField] protected StatItemConfig _config;
    public StatItemConfig Config => _config;
    private void Start()
    {
        _renderer.sprite = _config.Image;
    }
    private void OnValidate()
    {
        if (_config)
            gameObject.name = _config.Name;
    }

    protected override void ApplyEffect()
    {
        _itemApplier.ApplyEffectItem(_config);
        Destroy(gameObject);
    }
}