using System.Collections;
using Damage;
using UnityEngine;

namespace Weapons
{
    public class MeleeWeapon : BaseWeapon
    {
        [SerializeField] protected DamageDealer _damageDealer;

        private void Awake()
        {
            
            _damageDealer.OnDamage += HitToEnemy;
        }

        private void OnDestroy()
        {
            _damageDealer.OnDamage += HitToEnemy;
        }

        protected override void Launch()
        {
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            _damageDealer.gameObject.SetActive(true);
            yield return new WaitForSeconds(_weaponParams.LifeTime);
            _damageDealer.gameObject.SetActive(false);
        }

        private void HitToEnemy(EnemyDamageRecivier enemyDamage)
        {
            enemyDamage.ApplyDamage(_weaponParams.DamageAmount, _weaponParams.KnockAmount);
        }
    }
}