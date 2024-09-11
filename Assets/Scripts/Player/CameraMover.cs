using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _targetToMove;
    [SerializeField] private Vector3 _offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _offset + _targetToMove.position;
    }
}
