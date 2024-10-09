using Items;
using UnityEngine;
using Weapons;
using Zenject;

namespace Player.ItemPicked
{
    public class TestGiveWeapon : MonoBehaviour
    {
        public WeaponItemConfig _homing;
        public WeaponItemConfig _direction;
        public WeaponItemConfig _striaght;

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