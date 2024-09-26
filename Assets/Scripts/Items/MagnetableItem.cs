using DG.Tweening;
using UnityEngine;

namespace Items
{
    public abstract class MagnetableItem : PickableItem
    {
        public bool IsPicked { get; private set; }
        private bool _isFlyingToTarget;
    
        private float _backDistance = 3f;
        private float _backDuration = 0.3f;
        private float _flySpeed = 20;
    
        private Transform _targetPoint;
        private Tween _backwardFlyTween;


        public void StartMagnetItem(Transform targetPoint)
        {
            IsPicked = true;
            _targetPoint = targetPoint;
            Vector3 directionToTarget = (targetPoint.position - transform.position).normalized;
            Vector3 backPosition = transform.position - directionToTarget * _backDistance;
            _backwardFlyTween = transform.DOMove(backPosition, _backDuration).SetEase(Ease.InOutCirc).OnComplete(() =>
            {
                _isFlyingToTarget = true;
            });
        }

        protected override void ApplyEffectInternal()
        {
            IsPicked = false;
            _isFlyingToTarget = false;
            _backwardFlyTween.Kill();
        }


        void Update()
        {
            if (_isFlyingToTarget)
            {
                FlyTowardsTarget();
            }
        }

        void FlyTowardsTarget()
        {
            Vector3 directionToTarget = (_targetPoint.position - transform.position).normalized;
            transform.position += directionToTarget * _flySpeed * Time.deltaTime;
        }
    }
}