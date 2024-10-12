using UnityEngine.Events;

namespace Enemies
{
    public interface IEnemyFactory
    {
        public UnityAction<Enemy> OnEnemyDead { get; set; }
        public Enemy TrySpawnEnemy(EnemyConfig enemyConfig, int maxCount);
        public int GetCountAliveEnemy(EnemyConfig enemyConfig);
    }
}