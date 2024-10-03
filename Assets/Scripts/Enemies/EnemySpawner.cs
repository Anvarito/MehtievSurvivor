using Infrastructure.Extras;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemySpawner : ITickable, IInitializable
    {
        private readonly IEnemyFactory _enemyFactory;
        private float _spawnOffset = 2f;  
        private float _minDistanceFromEdge = 1f;
        private float _timer = 0;
        private float _cooldown = 1;
        private Camera _camera;
        private Vector3 _spawnPosition;
        private Vector3 _screenBottomLeft;
        private Vector3 _screenTopRight;

        public EnemySpawner(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }
        
        public void Initialize()
        {
            _camera = Camera.main;
        }
        
        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer > _cooldown)
            {
                _timer = 0;
                SpawnEnemy();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpawnEnemy();
            }
        }

        void SpawnEnemy()
        {
            Enemy enemy = _enemyFactory.GetEnemy();
            enemy.gameObject.SetActive(true);
            enemy.transform.position = ScreenObjectFinder.GetRandomPointBeyondScreen(_camera,_spawnOffset, _minDistanceFromEdge);
        }
    }
}