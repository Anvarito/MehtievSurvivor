using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemySpawner : ITickable
    {
        private readonly IEnemyFactory _enemyFactory;
        private float _spawnOffset = 2f;  
        private float _minDistanceFromEdge = 1f;
        private float _timer = 0;
        private float _cooldown = 2;


        public EnemySpawner(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }
        
        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer > _cooldown)
            {
                _timer = 0;
                SpawnEnemy();
            }
        }

        void SpawnEnemy()
        {
            var camera = Camera.main;
            Vector3 screenBottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
            Vector3 screenTopRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

            int side = Random.Range(0, 4);

            Vector3 spawnPosition = Vector3.zero;

            switch (side)
            {
                case 0:
                    spawnPosition = new Vector3(screenBottomLeft.x - _spawnOffset, Random.Range(screenBottomLeft.y + _minDistanceFromEdge, screenTopRight.y - _minDistanceFromEdge), 0);
                    break;
                case 1:
                    spawnPosition = new Vector3(screenTopRight.x + _spawnOffset, Random.Range(screenBottomLeft.y + _minDistanceFromEdge, screenTopRight.y - _minDistanceFromEdge), 0);
                    break;
                case 2:
                    spawnPosition = new Vector3(Random.Range(screenBottomLeft.x + _minDistanceFromEdge, screenTopRight.x - _minDistanceFromEdge), screenBottomLeft.y - _spawnOffset, 0);
                    break;
                case 3:
                    spawnPosition = new Vector3(Random.Range(screenBottomLeft.x + _minDistanceFromEdge, screenTopRight.x - _minDistanceFromEdge), screenTopRight.y + _spawnOffset, 0);
                    break;
            }

            EnemyMove enemyMove = _enemyFactory.Create();
            enemyMove.gameObject.SetActive(true);
            enemyMove.transform.position = spawnPosition;
        }


        
    }
}