using DG.Tweening;
using UnityEngine;

namespace SpriteAnimation
{
    public abstract class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        protected Tween _hitBlinkTween;

        public virtual void Reset()
        {
            _hitBlinkTween.Kill();
            _spriteRenderer.material.SetFloat("_Alpha", 0);
            _spriteRenderer.color = new Color(1, 1, 1, 1);
        }

        public virtual void HitAnimation()
        {
            _hitBlinkTween = _spriteRenderer.material.DOFloat(1f, "_Alpha", 0.1f)
                .SetEase(Ease.Linear)
                .SetLoops(2, LoopType.Yoyo); 
        }
    }
}