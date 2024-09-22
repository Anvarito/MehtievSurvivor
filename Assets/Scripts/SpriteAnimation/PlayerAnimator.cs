using Damage;
using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Player.PlayerMove
{
    public class PlayerAnimator : CharacterAnimation
    {
        [SerializeField] private DamageRecivier _damageRecivier;
        private InputService _inputService;
        private Vector3 _rightTurn = Vector3.one;
        private Vector3 _leftTurn = new Vector3(-1,1,1);

        [Inject]
        private void Construct(InputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _inputService.OnInputDirection += MoveInput;
            //_damageRecivier.OnDamage += TakeDamage;
        }
        private void TakeDamage(float arg0)
        {
            HitAnimation();
        }

        private void MoveInput(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;

            _spriteRenderer.transform.localScale = direction.x > 0 ? _leftTurn : _rightTurn;
        }

        private void OnDestroy()
        {
            _inputService.OnInputDirection -= MoveInput;
            //_damageRecivier.OnDamage -= TakeDamage;
        }
    }
}