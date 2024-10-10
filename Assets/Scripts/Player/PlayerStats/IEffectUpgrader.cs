using Items;

namespace Player.PlayerStats
{
    public interface IEffectUpgrader
    {
        public void ApplyEffect(StatItemConfig statItemConfig);
    }
}