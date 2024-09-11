using Items;

public class ItemReceiver
{
    private readonly IInventory _inventory;
    private readonly StatsBar _statsBar;
    private readonly PlayerStatsData _playerStatsData;

    public ItemReceiver(IInventory inventory, StatsBar statsBar, PlayerStatsData playerStatsData)
    {
        _inventory = inventory;
        _statsBar = statsBar;
        _playerStatsData = playerStatsData;

        _inventory.OnItemClick += TakeEffect;
        
        _statsBar.WisdomChange(_playerStatsData.Wisdom);
        _statsBar.SpeedChange(_playerStatsData.Speed);
        _statsBar.StregthChange(_playerStatsData.Strength);
        _statsBar.HealChange(_playerStatsData.Heal);
    }

    private void TakeEffect(ItemConfig item)
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

    }
}