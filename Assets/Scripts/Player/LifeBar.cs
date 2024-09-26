using System;
using HitPointsDamage;
using UnityEngine;

namespace Player
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _HPbar;
        private Material _material;
        private IHitPoints _hitPointsHolder;

        public void SetHPholder(IHitPoints hitPoints)
        {
            _hitPointsHolder = hitPoints;
        }
        private void Awake()
        {
            _material = _HPbar.material;
            _hitPointsHolder.CurrentHitPoints.Changed += CurrentHitPointsChanged;
            _hitPointsHolder.MaxHitPoints.Changed += MaxHitPointsChanged;
        }


        private void OnDestroy()
        {
            _hitPointsHolder.CurrentHitPoints.Changed -= CurrentHitPointsChanged;
            _hitPointsHolder.MaxHitPoints.Changed -= MaxHitPointsChanged;
        }

        private void MaxHitPointsChanged(float newMaxHP)
        {
            SetValue(_hitPointsHolder.CurrentHitPoints.value / newMaxHP);
        }
        private void CurrentHitPointsChanged(float currentHP)
        {
            SetValue(currentHP / _hitPointsHolder.MaxHitPoints.value);
        }

        private void SetValue(float value)
        {
            _material.SetFloat("_Slide", value);
        }
    }
}