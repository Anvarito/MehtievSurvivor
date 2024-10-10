using Items;

namespace Player.PlayerStats
{
    public interface IEffectContainer
    {
        public void AddStatItem(StatItemConfig itemConfig);
        bool CheckEffect(EStatType statType);
    }
}