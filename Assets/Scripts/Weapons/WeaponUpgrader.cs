using Items;

namespace Weapons
{
    public class WeaponUpgrader : IWeaponUpgrader
    {
        private readonly IWeaponFactory _weaponFactory;

        public WeaponUpgrader(IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }

        public void UpdateWeapon(WeaponItemConfig itemConfig)
        {
            if (_weaponFactory.TryGetWeapon(itemConfig.WeaponConfig, out WeaponParamsHandler weaponParamsHandler))
            {
                weaponParamsHandler.ChangeTier();
            }
            else
            {
                _weaponFactory.CreateNewWeapon(itemConfig);
            }
        }
    }
}