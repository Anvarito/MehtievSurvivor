using Enemies;
using HitPointsDamage;
using Infrastructure.Services;
using Items;
using Player;
using Player.ItemPicked;
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
        [SerializeField] private PlayerDamageRecivier _playerDamageRecivier;
        [SerializeField] private ScreenInputHandler _screenInputHandler;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private ExpItem _expItemPrefab;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindSaveLoadService();
            BindPlayer();
            BindEffectReceiver();
            BindEnemyFactory();
            BindLevelUp();
            BindWeaponManagment();
        }

        private void BindWeaponManagment()
        {
            Container.BindInterfacesTo<WeaponUpgrader>().AsSingle().NonLazy();
            Container.BindInterfacesTo<WeaponFactory>().AsSingle()
                .WithArguments(weaponRootTransform, _defaultWeaponItem).NonLazy();
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

        private void BindEnemyFactory()
        {
            Container.BindInterfacesTo<EnemyFactory>().AsSingle().WithArguments(_enemyPrefab, _enemyConfig).NonLazy();
            Container.BindInterfacesTo<EnemySpawner>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyDropSpawner>().AsSingle().WithArguments(_expItemPrefab).NonLazy();
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
            Container.Bind<ItemEffectApplier>().AsSingle().NonLazy();
        }
    }
}