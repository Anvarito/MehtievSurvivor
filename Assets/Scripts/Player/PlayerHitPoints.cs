using System;
using Damage;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerHitPoints : IInitializable, IDisposable
    {
        private readonly PlayerStatsData _playerStatsData;
        private readonly PlayerDamageRecivier _damageRecivier;
        private readonly HitPointsBar _hitPointsBar;
        private float _maxHitPoints;
        private float _currentHitPoints;

        public PlayerHitPoints(PlayerStatsData playerStatsData, PlayerProvider playerProvider)
        {
            _playerStatsData = playerStatsData;
            _damageRecivier = playerProvider.PlayerTransform.GetComponent<PlayerDamageRecivier>();
            _hitPointsBar = playerProvider.PlayerTransform.GetComponentInChildren<HitPointsBar>();
        }

        public void Initialize()
        {
            _maxHitPoints = _playerStatsData.HP;
            _currentHitPoints = _maxHitPoints;
            _damageRecivier.OnDamage += ApplyDamage;
        }

        private void ApplyDamage(float amount)
        {
            Debug.Log("Player apply damage by " + amount);
            _currentHitPoints -= (int)amount;
            _hitPointsBar.SetValue(_currentHitPoints / _maxHitPoints);
            Debug.Log(_currentHitPoints);
        }

        public void Dispose()
        {
            _damageRecivier.OnDamage -= ApplyDamage;
        }
    }
}