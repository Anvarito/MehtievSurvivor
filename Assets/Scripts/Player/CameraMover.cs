using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _targetToMove;
    [SerializeField] private Vector3 _offset;
    private Vector3 _oldPosition;

    private void LateUpdate()
    {
        if (_targetToMove.position != _oldPosition)
            transform.position = _offset + _targetToMove.position;

        _oldPosition = _targetToMove.position;
    }
}