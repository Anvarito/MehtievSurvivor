using System.Collections.Generic;
using Enemy;
using HitPointsDamage;
using Infrastructure.Services;
using Items;
using Player;
using Player.PlayerStats;
using Plugins.Joystick.Scripts;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private LifeBar _lifeBar;
        [SerializeField] private PlayerDamageRecivier _playerDamageRecivier;
        [SerializeField] private ScreenInputHandler _screenInputHandler;
        [SerializeField] private Enemy.Enemy _enemyPrefab;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private StatsBar _statsBar;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private List<ItemConfig> _itemConfigs;
        private PlayerProvider _playerProvider;
        private PlayerStatsData _playerStatsData;
        private IHitPoints _playerHitPointsHolder;

        public override void InstallBindings()
        {
            BindInputService();
            BindSaveLoadService();
            BindInventory();
            BindItemDatabase();
            BindPlayer();
            BindEffectReceiver();
            BindEnemyFactory();

            //ExampleLoad();
        }

        private void BindPlayer()
        {
            _playerStatsData = _playerConfig.GetPlayerData();
            _player.InitialSpeed(_playerStatsData.Speed);
            
            _playerProvider = new PlayerProvider(_player, _playerDamageRecivier);
            _playerHitPointsHolder = new HitPointsHolder(_playerStatsData.HP, _playerDamageRecivier);
            _lifeBar.SetHPholder(_playerHitPointsHolder);
        }

        private void BindEnemyFactory()
        {
            Container.BindInterfacesTo<EnemyFactory>().AsSingle().WithArguments(_enemyPrefab, _enemyConfig, _playerProvider).NonLazy();
            Container.BindInterfacesTo<EnemySpawner>().AsSingle().NonLazy();
        }

        // private void ExampleLoad()
        // {
        //     ExampleLoadProvider exampleLoadProvider = new ExampleLoadProvider();
        //     exampleLoadProvider.LoadAndDestroy(LoadSomthing);
        // }
        //
        // private void LoadSomthing(GameObject result)
        // {
        //     print(result.gameObject.name);
        // }

        private void BindSaveLoadService()
        {
            Container.Bind<SaveLoadService>().AsSingle().NonLazy();
            Container.Bind<StatsSaveLoader>().AsSingle().NonLazy();
            Container.Bind<InventorySaveLoader>().AsSingle().NonLazy();
        }

        private void BindInventory() =>
            Container.BindInterfacesTo<Inventory>().FromInstance(_inventory).AsSingle().NonLazy();

        private void BindInputService()
        {
            Container.BindInterfacesTo<InputProvider>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ScreenInputHandler>().FromInstance(_screenInputHandler).AsSingle().NonLazy();
        }

        private void BindEffectReceiver()
        {
            Container.Bind<ItemEffectApplier>().AsSingle().WithArguments(_statsBar, _playerStatsData, _playerHitPointsHolder, _player).NonLazy();
        }

        private void BindItemDatabase()
        {
            ItemDatabase itemDatabase = new ItemDatabase(_itemConfigs);
            Container.Bind<ItemDatabase>().FromInstance(itemDatabase).AsSingle().NonLazy();
        }
    }
}