using HitPointsDamage;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Enemy _prefabRef;
        private readonly EnemyConfig _enemyConfig;
        private readonly PlayerProvider _playerProvider;
        private readonly Transform _target;

        private ObjectPool<Enemy> _enemyPool;

        public EnemyFactory(Enemy prefabRef, EnemyConfig enemyConfig, PlayerProvider playerProvider)
        {
            _prefabRef = prefabRef;
            _enemyConfig = enemyConfig;
            _playerProvider = playerProvider;
            _target = playerProvider.PlayerTransform;
            _enemyPool = new ObjectPool<Enemy>(_prefabRef, 0);
        }

        public Enemy GetEnemy()
        {
            Enemy enemy;
            bool isNew = _enemyPool.Get(out enemy);

            if (isNew)
            {
                EnemyStatsHolder statsHolder = _enemyConfig.GetEnemyData();
                var damageApplier = new DamageApplier(statsHolder, enemy.EnemyDamageRecivier);
                enemy.EnemyMove.SetTargetToMove(_target, statsHolder);
                enemy.Animator.SetTargetToSearch(_target);
                enemy.KnockSlide.SetTarget(_target);
                enemy.EnemyAttack.Initial(statsHolder,_playerProvider.PlayerDamageRecivier);
                enemy.CreateEnemy(statsHolder);

                enemy.OnDead += deadEnemy => { _enemyPool.Release(deadEnemy); };
            }
            else
            {
                _enemyConfig.ResetParams(enemy.StatsHolder);
                enemy.Reset();
            }

            enemy.gameObject.SetActive(false);
            return enemy;
        }
    }
}