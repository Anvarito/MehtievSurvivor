using UnityEngine;

namespace Items
{
    public abstract class ItemConfig : ScriptableObject
    {
        public string Name;
        public string Description;
        public Sprite Image;
    }
}