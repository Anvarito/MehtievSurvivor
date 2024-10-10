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
        public WeaponItemConfig _fist;

        [Inject] public IWeaponUpgrader upgradeController;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                upgradeController.UpdateOrAdd(_fist);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                upgradeController.UpdateOrAdd(_direction);
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                upgradeController.UpdateOrAdd(_striaght);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                upgradeController.UpdateOrAdd(_homing);
            }
        }
    }
}