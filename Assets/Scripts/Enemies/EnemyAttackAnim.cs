using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
    public class EnemyAttackAnim : EnemyAttack
    {
        [SerializeField] private SpriteRenderer _view;
        [SerializeField] private Sprite _condition1;
        [SerializeField] private Sprite _condition2;
        private bool _isAttack;
        private float _timer;

        protected override void Attack()
        {
            base.Attack();
            _view.sprite = _condition2;
            _isAttack = true;
        }

        private void Update()
        {
            if(!_isAttack)
                return;
            _timer += Time.deltaTime;
            if (_timer > 0.5f)
            {
                _view.sprite = _condition1;
                _timer = 0;
                _isAttack = false;
            }
        }
    }
}