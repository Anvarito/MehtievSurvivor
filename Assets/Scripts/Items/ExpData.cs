using UnityEngine;
using UnityEngine.Serialization;

namespace Configs.Items
{
    [CreateAssetMenu(fileName = "ExpConfig", menuName = "Item/Expirience")]
    public class ExpData : ScriptableObject
    {
        public int ExpCount = 1;
        public Sprite Sprite;
    }
}