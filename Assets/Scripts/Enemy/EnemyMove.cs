using UnityEngine;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Transform _target;
        private float _speed = 10;
        private float _knockbackTimer;
        private float _knockbackDuration = 0.2f;

        private void Start()
        {
            
        }

        public void SetTargetToMove(Transform target, float speed)
        {
            _target = target;
            _speed = speed;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Rotate()
        {
            _spriteRenderer.flipX = _target.transform.position.x < transform.position.x;
        }
        private void Move()
        {
            Vector2 moveDirection = _target.position - transform.position;
            Vector2 moveVector = moveDirection.normalized * _speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + moveVector);
        }
    }
}