using Player.PlayerStats;

namespace Items
{
    public interface IPickable
    {
        public void ApplyEffect(ItemEffectApplier itemEffectApplier);
    }
}