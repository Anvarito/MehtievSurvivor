using Player.ItemPicked;
using UnityEngine;
using UnityEngine.Events;

namespace Items
{
    public abstract class PickableItem : MonoBehaviour, IPickable
    {
        protected SpriteRenderer _renderer;
        protected ItemApplier itemApplier;
        public UnityAction<IPickable> OnPick { get; set; }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void ApplyEffect(ItemApplier itemApplier)
        {
            this.itemApplier = itemApplier;
            ApplyEffect();
            OnPick?.Invoke(this);
        }

        protected abstract void ApplyEffect();
    }
}