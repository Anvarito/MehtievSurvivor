using DG.Tweening;
using UnityEngine;

namespace Items
{
    public class ExpItem : MagnetableItem
    {
        public float Points { get; private set; }
        
        [SerializeField] private float swingAngle = 30f; // Угол покачивания
        [SerializeField] private float duration = 1f;
        private Tween _swingTween;

        public void SetPoints(Sprite sprite, float points)
        {
            _renderer.sprite = sprite;
            Points = points;
        }
        protected override void ApplyEffectInternal()
        {
            _swingTween.Kill();
            base.ApplyEffectInternal();
            _itemEffectApplier.ApplyExp(this);
        }

        private void OnEnable()
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,-swingAngle));
            _swingTween = transform.DORotate(new Vector3(0, 0, swingAngle), duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine); 
        }
        

        private void OnValidate()
        {
            name = "Exp";
        }
    }
}