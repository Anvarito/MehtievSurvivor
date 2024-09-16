using Plugins.Joystick.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

namespace Infrastructure.Services
{
    public class InputService : ITickable
    {
        private readonly ScreenInputHandler _screenInputHadnler;
        private Vector2 _mouseInputVector;
        private Vector2 _startMousePosition;
        public UnityAction<Vector2> OnInputDirection { get; set; }

        public InputService(ScreenInputHandler screenInputHadnler)
        {
            _screenInputHadnler = screenInputHadnler;
            
            _screenInputHadnler.OnMoveDrag += OnDrag;
            _screenInputHadnler.OnEndMoveDrag += OnEndDrag;
            _screenInputHadnler.OnUpPointer += OnPointerUp;
            _screenInputHadnler.OnDownPointer += OnPointerDown;
        }

        public void Tick()
        {
            Vector2 movementDirection = new Vector2(_mouseInputVector.x - _startMousePosition.x, _mouseInputVector.y - _startMousePosition.y);
            movementDirection = Vector2.ClampMagnitude(movementDirection, 1);
            OnInputDirection?.Invoke(movementDirection);
        }
        
        private void OnDrag(PointerEventData eventData)
        {
            _mouseInputVector = eventData.position;
        }
        
        private void OnEndDrag(PointerEventData eventData)
        {
            _mouseInputVector = Vector2.zero;
        }

        private void OnPointerUp(PointerEventData eventData)
        {
            _mouseInputVector = Vector2.zero;
            _startMousePosition = Vector2.zero;
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            _startMousePosition = eventData.position;
            _mouseInputVector = eventData.position;
        }

        public void CleanUp()
        {
            _screenInputHadnler.OnMoveDrag -= OnDrag;
            _screenInputHadnler.OnEndMoveDrag -= OnEndDrag;
            _screenInputHadnler.OnUpPointer -= OnPointerUp;
            _screenInputHadnler.OnDownPointer -= OnPointerDown;
        }

    }
}
