using System.Collections.Generic;
using System.Linq;
using Items;
using Weapons.Configs;

namespace Weapons
{
    public class WeaponContainer : IWeaponContainer
    {
        private readonly IWeaponFactory _weaponFactory;
        private readonly ItemPanel _itemPanel;
        private HashSet<WeaponParamsHandler> _weaponsList;

        public WeaponContainer(IWeaponFactory weaponFactory, ItemPanel itemPanel)
        {
            _weaponFactory = weaponFactory;
            _itemPanel = itemPanel;
            _weaponsList = new HashSet<WeaponParamsHandler>();
        }
      
        public bool TryGetWeapon(WeaponConfig itemConfig, out WeaponParamsHandler weaponParamsHandler)
        {
            weaponParamsHandler =
                _weaponsList.FirstOrDefault(handler => handler.Config == itemConfig);
            return weaponParamsHandler != null;
        }

        public void AddWeapon(WeaponItemConfig weaponItemConfig)
        {
            var newWeapon = _weaponFactory.CreateNewWeapon(weaponItemConfig);
            _weaponsList.Add(newWeapon);
            
            _itemPanel.SetNewWeapon(weaponItemConfig);
        }
    }
}