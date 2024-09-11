using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _targetToMove;
    [SerializeField] private Vector3 _offset;
   
    void Update()
    {
        transform.position = _offset + _targetToMove.position;
    }
}
