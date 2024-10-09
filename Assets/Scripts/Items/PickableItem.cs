using Player.ItemPicked;
using UnityEngine;
using UnityEngine.Events;

namespace Items
{
    public abstract class PickableItem : MonoBehaviour, IPickable
    {
        protected SpriteRenderer _renderer;
        protected ItemEffectApplier _itemEffectApplier;
        public UnityAction<IPickable> OnPick { get; set; }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void ApplyEffect(ItemEffectApplier itemEffectApplier)
        {
            _itemEffectApplier = itemEffectApplier;
            ApplyEffect();
            OnPick?.Invoke(this);
        }

        protected abstract void ApplyEffect();
    }
}