using Items;

public class ItemEffectReceiver
{
    private readonly IInventory _inventory;
    private readonly StatsBar _statsBar;
    private PlayerStatsData _playerStatsData;
    private readonly StatsSaveLoader _statsSaveLoader;

    public ItemEffectReceiver(IInventory inventory, StatsBar statsBar, PlayerStatsData playerStatsData, StatsSaveLoader statsSaveLoader)
    {
        _inventory = inventory;
        _statsBar = statsBar;
        _playerStatsData = playerStatsData;
        _statsSaveLoader = statsSaveLoader;

        _inventory.OnItemClick += TakeEffect;
        LoadData();
    }

    private void LoadData()
    {
        _playerStatsData = _statsSaveLoader.LoadStats();
        InitAllView();
    }

    private void InitAllView()
    {
        _statsBar.SpeedChange(_playerStatsData.Speed);
        _statsBar.HealChange(_playerStatsData.HP);
    }

    private void TakeEffect(ItemConfig item)
    {
        if (!item)
            return;
        /*
        switch (item.itemType)
        {
            
            case EStatType.Speed:
                _playerStatsData.Speed += item.EffectAmount;
                _statsBar.SpeedChange(_playerStatsData.Speed);
                break;
            case EStatType.HP:
                _playerStatsData.HP += item.EffectAmount;
                _statsBar.HealChange(_playerStatsData.HP);
                break;
        }
        */

        _statsSaveLoader.SaveStats(_playerStatsData);
    }
}