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
            
            case EStatType.MoveSpeed:
                _playerConfig.MoveSpeed += item.EffectAmount;
                _statsBar.SpeedChange(_playerConfig.MoveSpeed);
                break;
            case EStatType.MaxHP:
                _playerConfig.MaxHP += item.EffectAmount;
                _statsBar.HealChange(_playerConfig.MaxHP);
                break;
        }
        */

        _statsSaveLoader.SaveStats(_playerConfig);
    }
}