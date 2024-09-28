using System;
using DG.Tweening;
using SpriteAnimation;
using UnityEngine;

namespace Enemies
{
    public class EnemyAnimation : CharacterAnimation
    {
        private Transform _target;
        private Tween _rotateTween;
        private Tween _fadeTween;

        public override void Reset()
        {
            _rotateTween.Kill();
            _fadeTween.Kill();
            transform.rotation = Quaternion.identity; 
            base.Reset();
        }

        public void SetTargetToSearch(Transform target)
        {
            _target = target;
        }

        public void DeadAnimation(float duration, Action onCompleteAnim = null)
        {
            HitAnimation();
        
            int clockwise = _target.transform.position.x < transform.position.x ? -1 : 1;
        
            _rotateTween = transform.DORotate(new Vector3(0, 0, 360 * clockwise), 0.5f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
        
            _fadeTween = _spriteRenderer
                .DOFade(0, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    onCompleteAnim?.Invoke();
                });
        }
    
    }
}
