using System;
using Items;
using Player.ItemPicked;
using UnityEngine;
using Zenject;

namespace UI
{
    public class LevelUpProcess : IInitializable, IDisposable
    {
        private LevelUpMenu _levelUpMenu;
        private readonly ExpAccumulator _expAccumulator;
        private readonly PlayerStatsHolder _playerStatsHolder;
        private readonly ItemApplier _itemApplier;

        public LevelUpProcess(LevelUpMenu levelUpMenu, ExpAccumulator expAccumulator, PlayerStatsHolder playerStatsHolder, ItemApplier itemApplier)
        {
            _levelUpMenu = levelUpMenu;
            _expAccumulator = expAccumulator;
            _playerStatsHolder = playerStatsHolder;
            _itemApplier = itemApplier;
        }
        public void Initialize()
        {
            _levelUpMenu.OnPress += Complete;
            _playerStatsHolder.Level.Changed += LaunchLevelUp;
        }
        public void Dispose()
        {
            _levelUpMenu.OnPress -= Complete;
            _playerStatsHolder.Level.Changed -= LaunchLevelUp;
        }
        
        private void LaunchLevelUp(int level)
        {
            _levelUpMenu.Open();
        }

        private void Complete(ItemConfig itemConfig)
        {
            if (itemConfig is WeaponItemConfig weaponItemConfig)
                _itemApplier.ApplyWeaponItem(weaponItemConfig);
            if (itemConfig is StatItemConfig statItemConfig)
                _itemApplier.ApplyEffectItem(statItemConfig);

            _levelUpMenu.Close();
            _expAccumulator.CompleteLevelUpAction();
        }
    }
}