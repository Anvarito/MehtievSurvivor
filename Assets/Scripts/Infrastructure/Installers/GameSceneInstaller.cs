using HitPointsDamage;
using Infrastructure.Services;
using Items;
using Player;
using Player.ItemPicked;
using Player.PlayerStats;
using Plugins.Joystick.Scripts;
using UI;
using UnityEngine;
using Weapons;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private WeaponItemConfig _defaultWeaponItem;
        [SerializeField] private WeaponRootTransform weaponRootTransform;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private LevelUpMenu _levelUpMenu;
        [SerializeField] private ItemPanel _itemPanel;
        [SerializeField] private PlayerDamageRecivier _playerDamageRecivier;
        [SerializeField] private ScreenInputHandler _screenInputHandler;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindSaveLoadService();
            BindPlayer();
            BindEffectReceiver();
            BindLevelUp();
            BindWeaponAppliers();
            BindEffectAppliers();
            BindGameTimer();
        }

        private void BindGameTimer()
        {
            Container.BindInterfacesTo<GameTimer>().AsSingle().WithArguments((float)30).NonLazy();
        }

        private void BindEffectAppliers()
        {
            Container.BindInterfacesTo<EffectUpgrader>().AsSingle();
            Container.BindInterfacesTo<EffectContainer>().AsSingle().WithArguments(_itemPanel);
        }

        private void BindWeaponAppliers()
        {
            Container.BindInterfacesTo<WeaponUpgrader>().AsSingle().WithArguments(_defaultWeaponItem);
            Container.BindInterfacesTo<WeaponContainer>().AsSingle().WithArguments(_itemPanel);
            Container.BindInterfacesTo<WeaponFactory>().AsSingle().WithArguments(weaponRootTransform);
        }

        private void BindLevelUp()
        {
            Container.BindInterfacesAndSelfTo<ExpAccumulator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelUpProcess>().AsSingle().WithArguments(_levelUpMenu).NonLazy();
        }

        private void BindPlayer()
        {
            var playerStatsHolder = _playerConfig.GetNewPlayerData();
            Container.Bind<PlayerStatsHolder>().FromInstance(playerStatsHolder).AsSingle();
            Container.Bind<PlayerProvider>().AsSingle().WithArguments(_player, _playerDamageRecivier);
            var damageApplier = new DamageApplier(playerStatsHolder, _playerDamageRecivier);
        }


        private void BindSaveLoadService()
        {
            Container.BindInterfacesTo<SaveLoadService>().AsSingle().NonLazy();
        }

        private void BindInputService()
        {
            Container.BindInterfacesTo<InputProvider>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ScreenInputHandler>().FromInstance(_screenInputHandler).AsSingle().NonLazy();
        }

        private void BindEffectReceiver()
        {
            Container.Bind<ItemApplier>().AsSingle().NonLazy();
        }
    }
}