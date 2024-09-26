
namespace Items
{
    public class ExpItem : MagnetableItem
    {
        protected override void ApplyEffectInternal()
        {
            base.ApplyEffectInternal();
            _itemEffectApplier.ApplyExp(this);
        }

        private void OnValidate()
        {
            name = "Exp";
        }
    }
}