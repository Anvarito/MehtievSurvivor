using Infrastructure.Extras;
using Scenarios;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace Enemies
{
    public class EnemySpawner : ITickable, IInitializable
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWaveChanger _waveChanger;
        private readonly IEnemyPoolHolder _enemyPoolHolder;

        private float _spawnOffset = 2f;
        private float _minDistanceFromEdge = 1f;

        private float _timer = 0;
        private Camera _camera;

        public EnemySpawner(IEnemyFactory enemyFactory, IWaveChanger waveChanger, IEnemyPoolHolder enemyPoolHolder)
        {
            _enemyFactory = enemyFactory;
            _waveChanger = waveChanger;
            _enemyPoolHolder = enemyPoolHolder;
        }

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void Tick()
        {
            if (Time.time > _timer)
            {
                Wave wave = _waveChanger.GetCurrentWave();
                _timer = Time.time + wave.SpawnCooldown;

                int randomIndex = new Random().Next(wave.EnemyConfigs.Count);
                var randomConfig = wave.EnemyConfigs[randomIndex];
                TrySpawnEnemy(randomConfig, wave.MaxCount);
            }
        }

        private void TrySpawnEnemy(EnemyConfig config, int maxCountInWave)
        {
            var pool = _enemyPoolHolder.GetPoolByConfig(config);
            if (pool.GetActiveCount() < maxCountInWave)
            {
                Enemy enemy = _enemyFactory.SpawnEnemy(pool, config);
                if (enemy)
                    enemy.transform.position =
                        ScreenObjectFinder.GetRandomPointBeyondScreen(_camera, _spawnOffset, _minDistanceFromEdge);
            }
        }
    }
}