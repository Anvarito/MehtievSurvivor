using System.Collections;
using Damage;
using UnityEngine;
using Weapons.Configs;

namespace Weapons
{
    public class BaseWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponDamageDealer _weaponDamageDealer;
        [SerializeField] private WeaponConfig _weaponConfig;
        private float _timer;

        private void Awake()
        {
            _weaponDamageDealer.OnDamage += HitToEnemy;
        }

        private void OnDestroy()
        {
            _weaponDamageDealer.OnDamage -= HitToEnemy;
        }

        private void HitToEnemy(EnemyDamageRecivier enemyDamage)
        {
            enemyDamage.ApplyDamage(_weaponConfig.DamageAmount, _weaponConfig.KnockAmount);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _weaponConfig.Cooldown)
            {
                StartCoroutine(LaunchWeapon());
                _timer = 0;
            }
        }

        private IEnumerator LaunchWeapon()
        {
            _weaponDamageDealer.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            _weaponDamageDealer.gameObject.SetActive(false);
        }
    }
}