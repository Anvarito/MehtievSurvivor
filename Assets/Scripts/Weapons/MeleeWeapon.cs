using System.Collections;
using Damage;
using UnityEngine;
using Weapons.Configs;

namespace Weapons
{
    public class MeleeWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponDamageDealer _weaponDamageDealer;
        [SerializeField] private WeaponConfig _weaponConfig;
        private float _cooldown;

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
            if (Time.time > _cooldown)
            {
                StartCoroutine(LaunchWeapon());
                _cooldown = Time.time + _weaponConfig.Cooldown;
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