using UnityEngine;
using Weapons.Configs;
using Zenject;

namespace Player.ItemPicked
{
    public class TestGiveWeapon : MonoBehaviour
    {
        public WeaponConfig _homing;
        public WeaponConfig _direction;
        public WeaponConfig _striaght;

        [Inject] public ItemEffectApplier itemEffectApplier;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                itemEffectApplier.ApplyWeapon(_homing);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                itemEffectApplier.ApplyWeapon(_direction);
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                itemEffectApplier.ApplyWeapon(_striaght);
                
            }
        }
    }
}