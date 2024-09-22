using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Player.PlayerMove
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _mainImage;
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
        }

        private void MoveInput(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;

            _mainImage.transform.localScale = direction.x > 0 ? _leftTurn : _rightTurn;
        }

        private void OnDestroy()
        {
            _inputService.OnInputDirection -= MoveInput;
        }
    }
}