using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "_inventory/ItemData")]
    public class ItemConfig : ScriptableObject
    {
        public string Name;
        public Sprite Image;
        public EItemType itemType;
        public int EffectAmount;
    }
}