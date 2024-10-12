using Infrastructure.Services;
using Scenarios;

namespace Enemies
{
    public interface IWaveChanger
    {
        public Wave GetCurrentWave();
    }
    
    public class WaveChanger : IWaveChanger
    {
        private readonly SpawnSequence _spawnSequence;
        private readonly IGameTimer _gameTimer;
        private int _indexWave = 0;

        public WaveChanger(SpawnSequence spawnSequence, IGameTimer gameTimer)
        {
            _spawnSequence = spawnSequence;
            _gameTimer = gameTimer;
        }


        public Wave GetCurrentWave()
        {
            if (_indexWave >= _spawnSequence.Waves.Count - 1)
                return _spawnSequence.Waves[^1];
            
            if (_gameTimer.GetElapsedTimeInMinutes() > _spawnSequence.Waves[_indexWave].TimeTreshold)
            {
                _indexWave++;
            }

            return _spawnSequence.Waves[_indexWave];
        }
    }
}