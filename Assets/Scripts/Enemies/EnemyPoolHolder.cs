using System.Collections.Generic;
using Infrastructure.Extras;
using Zenject;

namespace Enemies
{
    public interface IEnemyPoolHolder
    {
        public ObjectPool<Enemy> GetPoolByConfig(EnemyConfig enemyConfig);
    }
    
    public class EnemyPoolHolder : IEnemyPoolHolder, IInitializable
    {
        private Dictionary<EnemyConfig, ObjectPool<Enemy>> _pools;
        public void Initialize()
        {
            _pools = new Dictionary<EnemyConfig, ObjectPool<Enemy>>();
        }
        public ObjectPool<Enemy> GetPoolByConfig(EnemyConfig enemyConfig)
        {
            ObjectPool<Enemy> enemyPool = null;
            if (_pools.TryGetValue(enemyConfig, out ObjectPool<Enemy> pool))
            {
                enemyPool = pool;
            }
            else
            {
                enemyPool = new ObjectPool<Enemy>(enemyConfig.Prefab, 0);
                _pools.Add(enemyConfig, enemyPool);
            }

            return enemyPool;
        }
    }
}