using Items;

public class ItemEffectReceiver
{
    private readonly IInventory _inventory;
    private readonly StatsBar _statsBar;
    private PlayerConfig _playerConfig;
    private readonly StatsSaveLoader _statsSaveLoader;

    public ItemEffectReceiver(IInventory inventory, StatsBar statsBar, PlayerConfig playerConfig, StatsSaveLoader statsSaveLoader)
    {
        _inventory = inventory;
        _statsBar = statsBar;
        _playerConfig = playerConfig;
        _statsSaveLoader = statsSaveLoader;

        _inventory.OnItemClick += TakeEffect;
        LoadData();
    }

    private void LoadData()
    {
        _playerConfig = _statsSaveLoader.LoadStats();
        InitAllView();
    }

    private void InitAllView()
    {
    }

    private void TakeEffect(ItemConfig item)
    {
        if (!item)
            return;
        /*
        switch (item.itemType)
        {
            
            case EStatType.Speed:
                _playerConfig.Speed += item.EffectAmount;
                _statsBar.SpeedChange(_playerConfig.Speed);
                break;
            case EStatType.HP:
                _playerConfig.HP += item.EffectAmount;
                _statsBar.HealChange(_playerConfig.HP);
                break;
        }
        */

        _statsSaveLoader.SaveStats(_playerConfig);
    }
}