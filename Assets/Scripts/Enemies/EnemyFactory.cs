using HitPointsDamage;
using Infrastructure.Extras;
using Items;
using Player;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Enemies
{
    public class EnemyFactory : IEnemyFactory, IInitializable
    {
        private readonly Enemy _prefabRef;
        private readonly EnemyConfig _enemyConfig;
        private readonly PlayerProvider _playerProvider;
        private readonly Transform _target;

        private MonobehPool<Enemy> _enemyPool;
        private GameObject _root;
        public UnityAction<Enemy> OnEnemyDead { get; set; }

        public EnemyFactory(Enemy prefabRef, EnemyConfig enemyConfig,
            PlayerProvider playerProvider)
        {
            _prefabRef = prefabRef;
            _enemyConfig = enemyConfig;
            _playerProvider = playerProvider;
            _target = playerProvider.PlayerTransform;
            _enemyPool = new MonobehPool<Enemy>(_prefabRef, 0);
        }

        public void Initialize()
        {
            _root = new GameObject("ENEMIES");
            _root.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        public Enemy GetEnemy()
        {
            Enemy enemy;
            bool isNew = _enemyPool.Get(out enemy);

            if (isNew)
            {
                enemy.transform.SetParent(_root.transform);
                EnemyStatsHolder statsHolder = _enemyConfig.GetEnemyData();
                var damageApplier = new DamageApplier(statsHolder, enemy.EnemyDamageRecivier);
                enemy.EnemyMove.SetTargetToMove(_target, statsHolder);
                enemy.Animator.SetTargetToSearch(_target);
                enemy.KnockSlide.SetTarget(_target);
                enemy.EnemyAttack.Initial(statsHolder, _playerProvider.PlayerDamageRecivier);
                enemy.CreateEnemy(statsHolder);

                enemy.OnDead += deadEnemy =>
                {
                    OnEnemyDead?.Invoke(deadEnemy);
                    _enemyPool.Release(deadEnemy);
                };
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