using Items;
using Weapons.Configs;

namespace Weapons
{
    public interface IWeaponFactory
    {
        public WeaponParamsHandler CreateNewWeapon(WeaponItemConfig itemConfig);
    }
}