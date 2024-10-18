using Damage;
using SpriteAnimation;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerAnimator : CharacterAnimation
    {
        [SerializeField] private DamageRecivier _damageRecivier;
        private IInputProvider _inputProvider;
        private Vector3 _rightTurn = Vector3.one;
        private Vector3 _leftTurn = new(-1,1,1);

        [Inject]
        private void Construct(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        private void Awake()
        {
            _inputProvider.OnMoveDirection += MoveInput;
        }
        private void MoveInput(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;

            _spriteRenderer.transform.localScale = direction.x > 0 ? _leftTurn : _rightTurn;
        }

        private void OnDestroy()
        {
            _inputProvider.OnMoveDirection -= MoveInput;
        }
    }
}