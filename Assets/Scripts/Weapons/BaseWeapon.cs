using UnityEngine;
using Weapons.Configs;

namespace Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        protected WeaponParams _weaponParams;
        
        protected float _cooldown;
        public void SetParams(WeaponParams weaponParams)
        {
            _weaponParams = weaponParams;
        }
        protected virtual void Update()
        {
            if (Time.time > _cooldown)
            {
                Launch();
                _cooldown = Time.time + _weaponParams.Cooldown;
            }
        }

        protected abstract void Launch();

        
    }
}