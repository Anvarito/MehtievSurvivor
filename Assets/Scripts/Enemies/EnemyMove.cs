using System;
using UnityEngine;

namespace Enemies
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private EnemyStatsHolder _statsHolder;
        private Transform _target;
        
        private float _speed = 10;
        private float _knockbackTimer;
        private float _knockbackDuration = 0.2f;

        private void Start()
        {
            
        }

        private void OnDestroy()
        {
            _statsHolder.Speed.Changed -= SpeedChange;
        }

        public void SetTargetToMove(Transform target, EnemyStatsHolder statsHolder)
        {
            _statsHolder = statsHolder;
            _target = target;
            _speed = _statsHolder.Speed.value;
            
            _statsHolder.Speed.Changed += SpeedChange;
        }

        private void SpeedChange(float value)
        {
            _speed = value;
        }

        private void Update()
        {
            Rotate();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector2 moveDirection = _target.position - transform.position;
            Vector2 moveVector = moveDirection.normalized * _speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + moveVector);
        }
        private void Rotate()
        {
            _spriteRenderer.flipX = _target.transform.position.x < transform.position.x;
        }
    }
}