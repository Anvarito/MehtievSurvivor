using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Enemy configs/EnemyConfig", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        public float HP;
        public float DamageAmount = 1;
        public float MoveSpeed = 10;
    }
}