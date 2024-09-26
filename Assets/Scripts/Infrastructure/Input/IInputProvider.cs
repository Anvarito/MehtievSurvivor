using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public interface IInputProvider
    {
        public UnityAction<Vector2> OnMoveDirection { get; set; }
        public UnityAction OnStopDirection { get; set; }
    }
}