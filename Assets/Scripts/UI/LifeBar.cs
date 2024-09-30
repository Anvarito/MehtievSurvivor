using UnityEngine;

namespace Player
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _HPbar;
        private Material _material;
        private PlayerStatsHolder _statsHolder;

        public void SetDataHolder(PlayerStatsHolder statsHolder)
        {
            _statsHolder = statsHolder;
        }
        private void Awake()
        {
            _material = _HPbar.material;
            _statsHolder.CurrentHP.Changed += CurrentHitPointsChanged;
            _statsHolder.MaxHP.Changed += MaxHitPointsChanged;

            SetValue(1);
        }


        private void OnDestroy()
        {
            _statsHolder.CurrentHP.Changed -= CurrentHitPointsChanged;
            _statsHolder.MaxHP.Changed -= MaxHitPointsChanged;
        }

        private void MaxHitPointsChanged(float newMaxHP)
        {
            SetValue(_statsHolder.CurrentHP.value / newMaxHP);
        }
        private void CurrentHitPointsChanged(float currentHP)
        {
            SetValue(currentHP / _statsHolder.MaxHP.value);
        }

        private void SetValue(float value)
        {
            _material.SetFloat("_Slide", value);
        }
    }
}