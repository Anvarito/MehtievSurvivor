using Infrastructure.Extras;
using Scenarios;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemySpawner : ITickable, IInitializable
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWaveChanger _waveChanger;

        private float _spawnOffset = 2f;
        private float _minDistanceFromEdge = 1f;

        private float _timer = 0;
        private Camera _camera;

        public EnemySpawner(IEnemyFactory enemyFactory, IWaveChanger waveChanger)
        {
            _enemyFactory = enemyFactory;
            _waveChanger = waveChanger;
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

                foreach (var config in wave.EnemyConfigs)
                {
                    TrySpawnEnemy(config, wave.MaxCount);
                }
            }
        }

        private void TrySpawnEnemy(EnemyConfig config, int waveMaxCount)
        {
            Enemy enemy = _enemyFactory.TrySpawnEnemy(config, waveMaxCount);
            if (enemy)
                enemy.transform.position =
                    ScreenObjectFinder.GetRandomPointBeyondScreen(_camera, _spawnOffset, _minDistanceFromEdge);
        }
    }
}