using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons
{
    public class TrowableWeaponDamageDealer : WeaponDamageDealer
    {
        private float _lifeTIme = 3;
        private float _speed;
        private Vector3 _direction;
    
        public UnityAction OnLifeTimeOver;

        public void Init(Vector3 transformPosition, float lifeTime, float speed)
        {
            _lifeTIme = Time.time + lifeTime;
            _speed = speed;
            _direction = (transformPosition - transform.position).normalized;
            transform.rotation = Quaternion.identity;
        
            transform.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }

        private void Update()
        {
            if (Time.time > _lifeTIme)
            {
                OnLifeTimeOver?.Invoke();
            }
        
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        }

        public void Dispose()
        {
            transform.DOKill();
        }
    }
}