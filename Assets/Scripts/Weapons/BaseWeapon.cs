using UnityEngine;
using Weapons.Configs;

namespace Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField] protected WeaponConfig _config;
        protected WeaponUpgradeData weaponUpgradeData;
        protected int _weaponLevel = -1;
        protected float _cooldown;
        
        public WeaponConfig Config => _config;

        protected virtual void Awake()
        {
            EncreaseLevelWeapon();
        }

        public void EncreaseLevelWeapon()
        {
            if (_weaponLevel + 1 < _config.weaponUpgradeDatas.Count)
            {
                _weaponLevel++;
                weaponUpgradeData = _config.weaponUpgradeDatas[_weaponLevel];
                print($"{_config.Name} is {weaponUpgradeData.DamageAmount} damage now");
            }
        }
        
        protected virtual void Update()
        {
            if (Time.time > _cooldown)
            {
                Launch();
                _cooldown = Time.time + weaponUpgradeData.Cooldown;
            }
        }

        protected abstract void Launch();
    }
}