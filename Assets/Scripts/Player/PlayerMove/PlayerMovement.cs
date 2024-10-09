using System;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private float _speed = 10;

        private IInputProvider _inputProvider;
        private Vector2 _movementDirection;
        private Vector2 _startMousePosition;
        private PlayerStatsHolder _playerStatsHolder;

        [Inject]
        private void Construct(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public void SetDataHolder(PlayerStatsHolder playerStatsHolder)
        {
            _playerStatsHolder = playerStatsHolder;
            _playerStatsHolder.Speed.Changed += ChangeSpeed;
        }

        public void ChangeSpeed(float value)
        {
            _speed = value;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _inputProvider.OnMoveDirection += Moving;
            _inputProvider.OnStopDirection += StopMoving;
        }

        private void OnDestroy()
        {
            _inputProvider.OnMoveDirection -= Moving;
            _inputProvider.OnStopDirection -= StopMoving;
            _playerStatsHolder.Speed.Changed -= ChangeSpeed;
        }

        private void Moving(Vector2 direction)
        {
            _movementDirection = direction;
        }

        private void StopMoving()
        {
            _movementDirection = Vector2.zero;
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _movementDirection * _speed * Time.fixedDeltaTime);
        }
    }
}