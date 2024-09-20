using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private EnemyMove _prefabRef;
        private readonly Transform _target;

        public EnemyFactory(EnemyMove prefabRef, PlayerProvider playerProvider)
        {
            _prefabRef = prefabRef;
            _target = playerProvider.PlayerTransform;
        }

        public EnemyMove Create()
        {
            EnemyMove enemy = Object.Instantiate(_prefabRef);
            enemy.SetTargetToMove(_target);
            enemy.GetComponent<EnemyAnimation>().SetTargetToMove(_target);
            enemy.gameObject.SetActive(false);
            return enemy;
        }
    }
}