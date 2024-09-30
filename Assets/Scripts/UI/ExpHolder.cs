using Infrastructure.Extras;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ExpHolder : IInitializable, ITickable
    {
        private readonly PlayerStatsHolder _playerStatsHolder;

        private readonly LevelUpProcess _levelUp;
        private ICurveCalculation _difficultEncreaser;

        private int _reachBorder = 3;
        private int _currentPoints = 0;

        public ExpHolder(PlayerStatsHolder playerStatsHolder, LevelUpProcess levelUp)
        {
            _playerStatsHolder = playerStatsHolder;
            _levelUp = levelUp;

            //Todo get game config for start reach border and level
        }

        public void Initialize()
        {
            _difficultEncreaser = new CubicCalculation(_reachBorder);
            //_difficultEncreaser = new TestCalculation();
            _reachBorder = _difficultEncreaser.Calculate(_playerStatsHolder.Level.value);

            _levelUp.OnComplete += CompleteLevelUpAction;
        }

        public void EncreaseExp(int amount)
        {
            _currentPoints += amount;
            TryEncreaseLevel();
        }
        private void CompleteLevelUpAction()
        {
            TryEncreaseLevel();
        }
        
        private void TryEncreaseLevel()
        {
            if (_currentPoints >= _reachBorder)
            {
                _currentPoints -= _reachBorder;
                _playerStatsHolder.Level.value++;
                _reachBorder = _difficultEncreaser.Calculate(_playerStatsHolder.Level.value);
                ChangeProgressData();
                _levelUp.LaunchLevelUp();
            }
            else
            {
                ChangeProgressData();
            }
        }
        
        private void ChangeProgressData()
        {
            _playerStatsHolder.Progress.value = (float)_currentPoints / (float)_reachBorder;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                for (int i = 0; i < 100; i++)
                    Debug.Log(_difficultEncreaser.Calculate(i));
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                EncreaseExp(2);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                EncreaseExp(10);
            }
        }
    }
}