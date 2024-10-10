using System.Collections.Generic;
using Items;
using Weapons.Configs;

namespace Weapons
{
    public interface IWeaponContainer
    {
        public bool TryGetWeapon(WeaponConfig itemConfig, out WeaponParamsHandler weaponParamsHandler);
        public void AddWeapon(WeaponItemConfig weaponItemConfig);
    }
}