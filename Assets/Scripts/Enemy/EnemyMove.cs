using UnityEngine;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        private Transform _target;
        [SerializeField] private float _Speed = 10;
        [SerializeField] private Rigidbody2D _rigidbody;

        public void SetTargetToMove(Transform target)
        {
            _target = target;
        }
        private void FixedUpdate()
        {
            Vector2 moveDirection = _target.position - transform.position;
            
            Vector2 moveVector = moveDirection.normalized * _Speed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(_rigidbody.position + moveVector);
        }
    }
}