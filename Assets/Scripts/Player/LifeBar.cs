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
            _hitPointsHolder.CurrentHitPoints.Changed += HPchanged;
        }

        private void OnDestroy()
        {
            _hitPointsHolder.CurrentHitPoints.Changed -= HPchanged;
        }

        private void HPchanged(float currentHP)
        {
            SetValue(currentHP / _hitPointsHolder.MaxHitPoints);
        }

        private void SetValue(float value)
        {
            _material.SetFloat("_Slide", value);
        }
    }
}