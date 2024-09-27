using System;
using Items;
using Player.ItemPicked;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ItemPicker : MonoBehaviour
    {
        protected ItemEffectApplier _itemEffectApplier;

        [Inject]
        private void Construct(ItemEffectApplier itemEffectApplier)
        {
            _itemEffectApplier = itemEffectApplier;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IPickable item))
            {
                item.ApplyEffect(_itemEffectApplier);
                Destroy(other.gameObject);
            }
        }
    }
}