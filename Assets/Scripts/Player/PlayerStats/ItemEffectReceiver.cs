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

    private async void LoadData()
    {
        _playerStatsData = await _statsSaveLoader.LoadStats();
        InitAllView();
    }

    private void InitAllView()
    {
        _statsBar.WisdomChange(_playerStatsData.Wisdom);
        _statsBar.SpeedChange(_playerStatsData.Speed);
        _statsBar.StregthChange(_playerStatsData.Strength);
        _statsBar.HealChange(_playerStatsData.Heal);
    }

    private async void TakeEffect(ItemConfig item)
    {
        if (!item)
            return;

        switch (item.itemType)
        {
            case EItemType.Wisdom:
                _playerStatsData.Wisdom += item.EffectAmount;
                _statsBar.WisdomChange(_playerStatsData.Wisdom);
                break;
            case EItemType.Speed:
                _playerStatsData.Speed += item.EffectAmount;
                _statsBar.SpeedChange(_playerStatsData.Speed);
                break;
            case EItemType.Strength:
                _playerStatsData.Strength += item.EffectAmount;
                _statsBar.StregthChange(_playerStatsData.Strength);
                break;
            case EItemType.Heal:
                _playerStatsData.Heal += item.EffectAmount;
                _statsBar.HealChange(_playerStatsData.Heal);
                break;
        }

        await _statsSaveLoader.SaveStats(_playerStatsData);
    }
}