using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _Speed = 10;
        [SerializeField] private float _angularSpeed = 10;
        private InputService _inputService;
        private Vector3 _newMoveDirection;
        private readonly int _runAnimState = Animator.StringToHash("Run");

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
            if (moveDirection != Vector2.zero)
            {
                _newMoveDirection = new Vector3(moveDirection.x, 0, moveDirection.y);
                RotatingTo(_newMoveDirection);
                _animator.SetBool(_runAnimState, true);
            }
            else
            {
                _newMoveDirection = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
                _animator.SetBool(_runAnimState, false);
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _newMoveDirection.normalized * _Speed * Time.fixedDeltaTime;
        }

        private void RotatingTo(Vector3 direction)
        {
            direction.y = 0;
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float alpha = _angularSpeed * Time.deltaTime;
            Quaternion newRotation = Quaternion.Slerp(currentRotation, targetRotation, alpha);

            transform.rotation = newRotation;
        }
    }
}