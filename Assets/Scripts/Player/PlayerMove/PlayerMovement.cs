using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private Rigidbody2D _rigidbody;

        private InputService _inputService;

        [Inject]
        private void Construct(InputService inputService)
        {
            _inputService = inputService;
        }

        public void InitialSpeed(float initialSpeed)
        {
            _speed = initialSpeed;
        }
        
        public void IncreaseSpeed(float value)
        {
            _speed += value;
        }

        private void Awake()
        {
            _inputService.OnInputDirection += MoveInput;
        }

        private void OnDestroy()
        {
            _inputService.OnInputDirection -= MoveInput;
        }

        private void MoveInput(Vector2 moveDirection)
        {
            float magnitude = Mathf.Clamp(moveDirection.magnitude, 0f, 113f);
            Vector2 moveVector = moveDirection.normalized * magnitude * _speed / 100 * Time.fixedDeltaTime;
            _rigidbody.MovePosition(_rigidbody.position + moveVector);
        }
    }
}