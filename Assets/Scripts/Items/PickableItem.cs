using Player.PlayerStats;
using UnityEngine;

namespace Items
{
    public abstract class PickableItem : MonoBehaviour, IPickable
    {
        protected SpriteRenderer _renderer;
        protected ItemEffectApplier _itemEffectApplier;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void ApplyEffect(ItemEffectApplier itemEffectApplier)
        {
            _itemEffectApplier = itemEffectApplier;
            ApplyEffectInternal();
        }

        protected abstract void ApplyEffectInternal();
    }
}