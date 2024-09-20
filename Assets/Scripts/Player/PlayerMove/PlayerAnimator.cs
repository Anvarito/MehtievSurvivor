using Infrastructure.Services;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Player.PlayerMove
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _mainImage;

        private InputService _inputService;

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

            _mainImage.flipX = direction.x > 0;
        }

        private void OnDestroy()
        {
            _inputService.OnInputDirection -= MoveInput;
        }
    }
}