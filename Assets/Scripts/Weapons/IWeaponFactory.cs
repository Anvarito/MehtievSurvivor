using Items;
using Weapons.Configs;

namespace Weapons
{
    public interface IWeaponFactory
    {
        public bool TryGetWeapon(WeaponConfig itemConfig, out WeaponParamsHandler weaponParamsHandler);
        public void CreateNewWeapon(WeaponItemConfig itemConfig);
    }
}