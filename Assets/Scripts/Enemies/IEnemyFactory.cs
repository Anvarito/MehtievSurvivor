using Infrastructure.Extras;
using UnityEngine.Events;

namespace Enemies
{
    public interface IEnemyFactory
    {
        public UnityAction<Enemy> OnEnemyDead { get; set; }
        public Enemy SpawnEnemy(ObjectPool<Enemy> pool,  EnemyConfig config);
    }
}