using System.Collections.Generic;
using HitPointsDamage;
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
        private Dictionary<EnemyConfig, ObjectPool<Enemy>> _pools;
        private GameObject _root;
        public UnityAction<Enemy> OnEnemyDead { get; set; }

        public EnemyFactory(PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
            _target = playerProvider.PlayerTransform;
            _pools = new Dictionary<EnemyConfig, ObjectPool<Enemy>>();
        }

        public void Initialize()
        {
            _root = new GameObject("ENEMIES");
            _root.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        private static void ReviveExistEnemy(EnemyConfig enemyConfig, Enemy enemy)
        {
            enemyConfig.ResetParams(enemy.StatsHolder);
            enemy.Reset();
        }

        private void CreateNewEnemy(EnemyConfig enemyConfig, Enemy enemy, ObjectPool<Enemy> pool)
        {
            enemy.transform.SetParent(_root.transform);
            EnemyStatsHolder statsHolder = enemyConfig.GetEnemyData();
            var damageApplier = new DamageApplier(statsHolder, enemy.EnemyDamageRecivier);
            enemy.EnemyMove.SetTargetToMove(_target, statsHolder);
            enemy.Animator.SetTargetToSearch(_target);
            enemy.KnockSlide.SetTarget(_target);
            enemy.EnemyAttack.Initial(statsHolder, _playerProvider.PlayerDamageRecivier);
            enemy.CreateEnemy(statsHolder, enemyConfig.Image);

            enemy.OnDead += deadEnemy =>
            {
                OnEnemyDead?.Invoke(deadEnemy);
                pool.Release(deadEnemy);
            };
        }
        
        private ObjectPool<Enemy> GetPoolByConfig(EnemyConfig enemyConfig)
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

        public Enemy TrySpawnEnemy(EnemyConfig enemyConfig, int maxCount)
        {
            var pool = GetPoolByConfig(enemyConfig);
            if (pool.GetActiveCount() < maxCount)
            {
                if (pool.Get(out Enemy enemy))
                {
                    CreateNewEnemy(enemyConfig, enemy, pool);
                }
                else
                {
                    ReviveExistEnemy(enemyConfig, enemy);
                }

                return enemy;
            }

            return null;
        }

        public int GetCountAliveEnemy(EnemyConfig enemyConfig)
        {
            var pool = GetPoolByConfig(enemyConfig);
            return pool.GetActiveCount();
        }
    }
}