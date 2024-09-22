using System.Collections.Generic;
using Enemy;
using HitPointsDamage;
using Infrastructure.Services;
using Items;
using Player;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private LifeBar _lifeBar;
        [SerializeField] private PlayerDamageRecivier _playerDamageRecivier;
        [SerializeField] private Enemy.Enemy _enemyPrefab;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private StatsBar _statsBar;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private List<ItemConfig> _itemConfigs;
        private PlayerStatsData _playerStatsData;
        private PlayerProvider _playerProvider;

        public override void InstallBindings()
        {
            BindInputService();
            BindSaveLoadService();
            BindInventory();
            BindEffectReceiver();
            BindItemDatabase();
            BindPlayer();
            BindEnemyFactory();

            //ExampleLoad();
        }

        private void BindPlayer()
        {
            _playerStatsData = new PlayerStatsData();
            _playerProvider = new PlayerProvider(_player);
            IHitPoints HPplayer = new HitPointsHolder(_playerStatsData.HP, _playerDamageRecivier);
            _lifeBar.SetHPholder(HPplayer);
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

        private void BindInputService() =>
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();

        private void BindEffectReceiver()
        {
            Container.Bind<ItemEffectReceiver>().AsSingle().WithArguments(_statsBar, _playerStatsData).NonLazy();
        }

        private void BindItemDatabase()
        {
            ItemDatabase itemDatabase = new ItemDatabase(_itemConfigs);
            Container.Bind<ItemDatabase>().FromInstance(itemDatabase).AsSingle().NonLazy();
        }
    }
}