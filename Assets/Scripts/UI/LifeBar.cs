using UnityEngine;
using Zenject;

namespace Player
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _HPbar;
        private Material _material;
        private PlayerStatsHolder _playerStatsHolder;

        [Inject]
        private void Construct(PlayerStatsHolder statsHolder)
        {
            _playerStatsHolder = statsHolder;
        }
        private void Awake()
        {
            _material = _HPbar.material;
            _playerStatsHolder.CurrentHP.Changed += CurrentHitPointsChanged;
            _playerStatsHolder.MaxHP.Changed += MaxHitPointsChanged;

            SetValue(1);
        }


        private void OnDestroy()
        {
            _playerStatsHolder.CurrentHP.Changed -= CurrentHitPointsChanged;
            _playerStatsHolder.MaxHP.Changed -= MaxHitPointsChanged;
        }

        private void MaxHitPointsChanged(float newMaxHP)
        {
            SetValue(_playerStatsHolder.CurrentHP.value / newMaxHP);
        }
        private void CurrentHitPointsChanged(float currentHP)
        {
            SetValue(currentHP / _playerStatsHolder.MaxHP.value);
        }

        private void SetValue(float value)
        {
            _material.SetFloat("_Slide", value);
        }
    }
}