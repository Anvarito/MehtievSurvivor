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
            Enemies.Enemy enemy = _enemyFactory.GetEnemy();
            enemy.gameObject.SetActive(true);
            enemy.transform.position = GetRandomPointBeyondScreen();
        }

        private Vector3 GetRandomPointBeyondScreen()
        {
            _screenBottomLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
            _screenTopRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, _camera.nearClipPlane));
            
            int side = Random.Range(0, 4);

            _spawnPosition = Vector3.zero;

            switch (side)
            {
                case 0:
                    _spawnPosition = new Vector3(_screenBottomLeft.x - _spawnOffset,
                        Random.Range(_screenBottomLeft.y + _minDistanceFromEdge, _screenTopRight.y - _minDistanceFromEdge), 0);
                    break;
                case 1:
                    _spawnPosition = new Vector3(_screenTopRight.x + _spawnOffset,
                        Random.Range(_screenBottomLeft.y + _minDistanceFromEdge, _screenTopRight.y - _minDistanceFromEdge), 0);
                    break;
                case 2:
                    _spawnPosition =
                        new Vector3(
                            Random.Range(_screenBottomLeft.x + _minDistanceFromEdge, _screenTopRight.x - _minDistanceFromEdge),
                            _screenBottomLeft.y - _spawnOffset, 0);
                    break;
                case 3:
                    _spawnPosition =
                        new Vector3(
                            Random.Range(_screenBottomLeft.x + _minDistanceFromEdge, _screenTopRight.x - _minDistanceFromEdge),
                            _screenTopRight.y + _spawnOffset, 0);
                    break;
            }

            return _spawnPosition;
        }

        
    }
}