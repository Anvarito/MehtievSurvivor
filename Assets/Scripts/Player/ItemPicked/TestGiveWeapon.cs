using UnityEngine;
using Weapons;
using Weapons.Configs;
using Zenject;

namespace Player.ItemPicked
{
    public class TestGiveWeapon : MonoBehaviour
    {
        public WeaponConfig _homing;
        public WeaponConfig _direction;
        public WeaponConfig _striaght;

        [Inject] public IWeaponUpgrader upgradeController;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                upgradeController.UpdateWeapon(_homing);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                upgradeController.UpdateWeapon(_direction);
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                upgradeController.UpdateWeapon(_striaght);
                
            }
        }
    }
}