using Items;
using Weapons.Configs;

namespace Weapons
{
    public interface IWeaponUpgrader
    {
        public void UpdateWeapon(WeaponItemConfig itemConfig);
    }
}