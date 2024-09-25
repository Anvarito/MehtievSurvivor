using UnityEngine;

namespace Items
{
    public abstract class ItemConfig : ScriptableObject
    {
        public string Name;
        public Sprite Image;
    }
}