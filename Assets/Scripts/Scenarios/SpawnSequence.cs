using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenarios
{
    [CreateAssetMenu(fileName = "Spawn sequence", menuName = "Scenario configs/Sequence", order = 1)]
    public class SpawnSequence : ScriptableObject
    {
        public List<Wave> Waves;
    }

    [Serializable]
    public class Wave
    {
        public List<EnemyConfig> EnemyConfigs;
        public float TimeTreshold;
        public float SpawnCooldown = 1;
        public int MaxCount = 10;
    }
}