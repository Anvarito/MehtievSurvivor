using Items;
using Zenject;

namespace Weapons
{
    public class WeaponUpgrader : IWeaponUpgrader, IInitializable
    {
        private readonly IWeaponContainer _weaponContainer;
        private readonly WeaponItemConfig _defaultWeapon;

        public WeaponUpgrader(IWeaponContainer weaponContainer, WeaponItemConfig defaultWeapon)
        {
            _weaponContainer = weaponContainer;
            _defaultWeapon = defaultWeapon;
        }

        public void UpdateOrAdd(WeaponItemConfig itemConfig)
        {
            if (_weaponContainer.TryGetWeapon(itemConfig.WeaponConfig, out WeaponParamsHandler weaponParamsHandler))
            {
                weaponParamsHandler.ChangeTier();
            }
            else
            {
                _weaponContainer.AddWeapon(itemConfig);
            }
        }

        public void Initialize()
        {
            UpdateOrAdd(_defaultWeapon);
        }
    }
}