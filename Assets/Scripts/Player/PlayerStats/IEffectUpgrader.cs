using Items;

namespace Player.PlayerStats
{
    public interface IEffectUpgrader
    {
        public void ApplyEffectItem(StatItemConfig statItemConfig);
        public void EncreaceStat(StatItemConfig statItemConfig);
    }
}