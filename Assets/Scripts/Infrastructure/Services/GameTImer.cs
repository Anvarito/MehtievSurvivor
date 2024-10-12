using System;
using Zenject;

namespace Infrastructure.Services
{
    public interface IGameTimer
    {
        public bool TimerFinished { get; set; }
        public float GetElapsedTimeInMinutes();
        public void ResetTimer();
    }
    public class GameTimer : ITickable, IGameTimer
    {
        private TimeSpan _targetTimeSpan;
        private float _elapsedTime;
        public bool TimerFinished { get; set; }

        public GameTimer(float minutes)
        {
            _targetTimeSpan = TimeSpan.FromMinutes(minutes);
        }

        public void Tick()
        {
            if(TimerFinished)
                return;
            
            _elapsedTime += UnityEngine.Time.deltaTime;

            if (_elapsedTime >= _targetTimeSpan.TotalSeconds)
            {
                TimerFinished = true;
            }
        }


        public void ResetTimer()
        {
            _elapsedTime = 0f;
            TimerFinished = false;
        }
        
        public float GetElapsedTimeInMinutes()
        {
            return _elapsedTime / 60f;
        }
    }
}