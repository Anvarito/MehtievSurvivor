using System;
using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _Speed = 10;
        [SerializeField] private Rigidbody2D _rigidbody;

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

        private void OnDestroy()
        {
            _inputService.OnInputDirection -= MoveInput;
        }

        private void MoveInput(Vector2 moveDirection)
        {
            float magnitude = Mathf.Clamp(moveDirection.magnitude, 0f, 113f);
            Vector2 moveVector = moveDirection.normalized * magnitude * _Speed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(_rigidbody.position + moveVector);
        }
    }
}