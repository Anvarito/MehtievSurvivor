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
        protected ItemApplier itemApplier;

        [Inject]
        private void Construct(ItemApplier itemApplier)
        {
            this.itemApplier = itemApplier;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IPickable item))
            {
                item.ApplyEffect(itemApplier);
            }
        }
    }
}