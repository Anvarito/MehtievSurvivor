using Player.ItemPicked;
using UnityEngine.Events;

namespace Items
{
    public interface IPickable
    {
        public UnityAction<IPickable> OnPick { get; set; }
        public void PickItem(ItemApplier itemApplier);
    }
}