using Player.ItemPicked;

namespace Items
{
    public interface IPickable
    {
        public void ApplyEffect(ItemEffectApplier itemEffectApplier);
    }
}