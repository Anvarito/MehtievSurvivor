using Plugins.Joystick.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

namespace Infrastructure.Services
{
    public class InputService : ITickable, IFixedTickable
    {
        private readonly ScreenInputHandler _screenInputHadnler;
        private Vector2 _mouseInputPosition;
        private Vector2 _mouseStartPosition;
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
            Vector2 movementDirection = _mouseInputPosition - _mouseStartPosition;
            OnInputDirection?.Invoke(movementDirection);
        }
        public void FixedTick()
        {
        }
        private void OnDrag(PointerEventData eventData)
        {
            _mouseInputPosition = eventData.position;
        }
        
        private void OnEndDrag(PointerEventData eventData)
        {
            _mouseInputPosition = Vector2.zero;
        }

        private void OnPointerUp(PointerEventData eventData)
        {
            _mouseInputPosition = Vector2.zero;
            _mouseStartPosition = Vector2.zero;
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            _mouseStartPosition = eventData.position;
            _mouseInputPosition = eventData.position;
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
