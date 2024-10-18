using Damage;
using DG.Tweening;
using SpriteAnimation;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class EnemyAnimation : CharacterAnimation
    {
        [SerializeField] private EnemyDamageRecivier _enemyDamageRecivier;
        
        private EnemyParams _enemyParams;
        private Transform _target;
        private Tween _rotateTween;
        private Tween _fadeTween;
        
        public UnityAction OnDieAnimationEnd;

        public void SetDependencies(Transform target, EnemyParams enemyParams)
        {
            _target = target;
            _enemyParams = enemyParams;
        }

        protected virtual void Awake()
        {
            _enemyDamageRecivier.OnKnock += HitAnimation;
        }

        private void DeadAnimation(float duration)
        {
            int clockwise = _target.transform.position.x < transform.position.x ? -1 : 1;

            _rotateTween = transform.DORotate(new Vector3(0, 0, 360 * clockwise), 0.5f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);

            _fadeTween = _spriteRenderer
                .DOFade(0, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    ResetAllTween();
                    OnDieAnimationEnd?.Invoke();
                });
        }

        private void HitAnimation(float value)
        {
            if (_enemyParams.CurrentHP.value <= 0)
            {
                DeadAnimation(1);
            }

            _hitBlinkTween = _spriteRenderer.material.DOFloat(1f, "_Alpha", 0.1f)
                .SetEase(Ease.Linear)
                .SetLoops(2, LoopType.Yoyo);
        }

        private void ResetAllTween()
        {
            _rotateTween.Kill();
            _fadeTween.Kill();
            _hitBlinkTween.Kill();
            
            _spriteRenderer.material.SetFloat("_Alpha", 0);
            _spriteRenderer.color = new Color(1, 1, 1, 1);
            
            transform.rotation = Quaternion.identity;
        }
    }
}