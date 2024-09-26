using System;
using Plugins.Joystick.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

namespace Player
{
    public class InputProvider : IInitializable, IDisposable, IFixedTickable, IInputProvider
    {
        private IScreenInputHadnler _screenInputHandler;
        private Vector2 _startMousePosition;
        private Vector2 _movementDirection;
        public UnityAction<Vector2> OnMoveDirection { get; set; }
        public UnityAction OnStopDirection { get; set; }

        private InputProvider(IScreenInputHadnler screenInputHandler)
        {
            _screenInputHandler = screenInputHandler;
        }

        public void Initialize()
        {
            _screenInputHandler.OnDownPointer += PointerDown;
            _screenInputHandler.OnUpPointer += UpPointer;
            _screenInputHandler.OnMoveDrag += MoveDrag;
        }

        public void Dispose()
        {
            _screenInputHandler.OnDownPointer -= PointerDown;
            _screenInputHandler.OnUpPointer -= UpPointer;
            _screenInputHandler.OnMoveDrag -= MoveDrag;
        }

        public void FixedTick()
        {
            float horizontal = Input.GetAxisRaw("Horizontal"); // По умолчанию это A/D или стрелки влево/вправо
            float vertical = Input.GetAxisRaw("Vertical"); // По умолчанию это W/S или стрелки вверх/вниз

            Vector2 keyboardDirection = new Vector2(horizontal, vertical).normalized;
            var direction = _movementDirection.sqrMagnitude > keyboardDirection.sqrMagnitude
                ? _movementDirection
                : keyboardDirection;
            if (direction != Vector2.zero)
                OnMoveDirection?.Invoke(direction);
            else
                OnStopDirection?.Invoke();
        }

        private void MoveDrag(PointerEventData pointPosition)
        {
            _movementDirection = new Vector2(pointPosition.position.x - _startMousePosition.x,
                pointPosition.position.y - _startMousePosition.y);

            var normalizedMagnitude = _movementDirection.magnitude / 100f;
            normalizedMagnitude = Mathf.Clamp01(normalizedMagnitude);

            _movementDirection = _movementDirection.normalized * normalizedMagnitude;
        }

        private void UpPointer(PointerEventData pointer)
        {
            _movementDirection = Vector2.zero;
            OnStopDirection?.Invoke();
        }

        private void PointerDown(PointerEventData pointer)
        {
            _startMousePosition = pointer.position;
        }
    }
}