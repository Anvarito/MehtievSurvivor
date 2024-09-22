using HitPointsDamage;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Enemy _prefabRef;
        private readonly EnemyConfig _enemyConfig;
        private readonly Transform _target;

        public EnemyFactory(Enemy prefabRef, EnemyConfig enemyConfig, PlayerProvider playerProvider)
        {
            _prefabRef = prefabRef;
            _enemyConfig = enemyConfig;
            _target = playerProvider.PlayerTransform;
        }

        public Enemy Get()
        {
            Enemy enemy = Object.Instantiate(_prefabRef);
            IHitPoints enemyHitPoints = new HitPointsHolder(_enemyConfig.HP, enemy.EnemyDamageRecivier);
            enemy.EnemyMove.SetTargetToMove(_target, _enemyConfig.MoveSpeed);
            enemy.Animator.SetTargetToSearch(_target);
            enemy.KnockSlide.SetTarget(_target);
            enemy.EnemyAttack.DamageAmount = _enemyConfig.DamageAmount;
            enemy.CreateEnemy(enemyHitPoints);
            enemy.gameObject.SetActive(false);
            return enemy;
        }
    }
}