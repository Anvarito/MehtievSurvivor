using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Enemy configs/EnemyConfig", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        public float AttackAmount = 1;
    }
}