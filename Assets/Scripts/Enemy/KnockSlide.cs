using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class KnockSlide : MonoBehaviour
    {
        [SerializeField] private EnemyMove _enemyMove;
        [SerializeField] private Rigidbody2D _rigidbody;
        private Transform _target;
        private IEnumerator _knockCoroutine;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void TakeKnock(float power)
        {
            if(_knockCoroutine != null) StopCoroutine(_knockCoroutine);
            var hitVector = (transform.position - _target.position).normalized * power;
            _rigidbody.AddForce(hitVector, ForceMode2D.Impulse);
        }

        public void KnockFinal(float power)
        {
            _enemyMove.enabled = false;
            TakeKnock(power);
        }

        public void Knock(float power)
        {
            TakeKnock(power);
            _knockCoroutine = UpTimer();
            StartCoroutine(_knockCoroutine);
        }

        private IEnumerator UpTimer()
        {
            _enemyMove.enabled = false;
            yield return new WaitForSeconds(0.2f);
            _enemyMove.enabled = true;
        }
    }
}