using System;
using System.Collections;
using Damage;
using UnityEngine;

namespace Enemies
{
    public class KnockSlide : MonoBehaviour
    {
        [SerializeField] private EnemyMove _enemyMove;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private EnemyDamageRecivier _damageRecivier;
        
        private Transform _target;
        private IEnumerator _knockCoroutine;
        private EnemyParams _params;

        private void Awake()
        {
            _damageRecivier.OnKnock += TakeKnock;
        }

        private void OnDestroy()
        {
            _damageRecivier.OnKnock -= TakeKnock;
        }

        public void SetDependencies(Transform target, EnemyParams enemyParams)
        {
            _target = target;
            _params = enemyParams;
        }

        private void TakeKnock(float power)
        {
            if (_params.CurrentHP.value > 0)
            {
                Knock(power);
            }
            else
            {
                KnockFinal(power);
            }
        }

        private void KnockFinal(float power)
        {
            Slide(power);
        }

        private void Knock(float power)
        {
            Slide(power);
            
            _knockCoroutine = UpTimer();
            StartCoroutine(_knockCoroutine);
        }

        private void Slide(float power)
        {
            if(_knockCoroutine != null) StopCoroutine(_knockCoroutine);
            var hitVector = (transform.position - _target.position).normalized * power;
            _rigidbody.AddForce(hitVector, ForceMode2D.Impulse);
        }

        private IEnumerator UpTimer()
        {
            _enemyMove.enabled = false;
            yield return new WaitForSeconds(0.2f);
            _enemyMove.enabled = true;
        }
    }
}