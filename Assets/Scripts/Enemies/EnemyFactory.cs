using Infrastructure.Extras;
using Player;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Enemies
{
    public class EnemyFactory : IEnemyFactory, IInitializable
    {
        private readonly PlayerProvider _playerProvider;
        private readonly Transform _target;
        private GameObject _root;
        public UnityAction<Enemy> OnEnemyDead { get; set; }

        public EnemyFactory(PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
            _target = playerProvider.PlayerTransform;
        }

        public void Initialize()
        {
            _root = new GameObject("ENEMIES");
            _root.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        private void ReviveEnemy(EnemyConfig enemyConfig, Enemy enemy)
        {
            enemy.Revive(enemyConfig.EnemyParams);
        }

        private void InitNewEnemy(EnemyConfig enemyConfig, Enemy enemy, ObjectPool<Enemy> pool)
        {
            enemy.transform.SetParent(_root.transform);
            EnemyParams enemyParams = enemyConfig.GetNewParams();
            enemy.Initialize(enemyParams,_target, _playerProvider.PlayerDamageRecivier);

            enemy.OnDead += deadEnemy =>
            {
                OnEnemyDead?.Invoke(enemy);
                pool.Release(deadEnemy);
            };
        }

        public Enemy SpawnEnemy(ObjectPool<Enemy> pool, EnemyConfig config)
        {
            if (pool.Get(out Enemy enemy))
            {
                InitNewEnemy(config, enemy, pool);
            }
            else
            {
                ReviveEnemy(config, enemy);
            }

            return enemy;
        }
    }
}