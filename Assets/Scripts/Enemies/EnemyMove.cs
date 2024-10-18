using UnityEngine;

namespace Enemies
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Transform _target;
        
        private float _speed = 10;
        private float _knockbackTimer;
        private float _knockbackDuration = 0.2f;

        public void SetDependencies(Transform target, EnemyParams data)
        {
            _target = target;
            _speed = data.Speed.value;
        }

        private void Update()
        {
            Flip();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector2 direction = _target.position - transform.position;
            Vector2 moveVector = direction.normalized * _speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + moveVector);
        }
        private void Flip()
        {
            _spriteRenderer.flipX = _target.transform.position.x < transform.position.x;
        }
    }
}