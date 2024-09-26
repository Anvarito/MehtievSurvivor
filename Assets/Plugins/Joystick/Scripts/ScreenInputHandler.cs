using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Plugins.Joystick.Scripts
{
    public class ScreenInputHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IScreenInputHadnler
    {
        public UnityAction<PointerEventData> OnMoveDrag { get; set; }
        public UnityAction<PointerEventData> OnEndMoveDrag { get; set; }
        public UnityAction<PointerEventData> OnUpPointer { get; set; }
        public UnityAction<PointerEventData> OnDownPointer { get; set; }
        
        private bool _isStartDrag = false;
        private PointerEventData _dragEventData;
    
        public void OnDrag(PointerEventData eventData)
        {
            //print("OnDrug" + eventData.pointerId);
            if(eventData.pointerId == -2)
                return;
            _isStartDrag = true;
            _dragEventData = eventData;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //print("OnEndDrug");
            if(eventData.pointerId == -2)
                return;
            _isStartDrag = false;
            _dragEventData = null;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //print("OnPointerDOwen");
            // if(eventData.pointerId == -2)
            //     return;
            OnDownPointer?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            //  print("OnPointerUp");
            if(eventData.pointerId == -2)
                return;
            OnUpPointer?.Invoke(eventData);
        }

        private void Update()
        {
            if(_isStartDrag)
                OnMoveDrag?.Invoke(_dragEventData);
        }

    }
}
