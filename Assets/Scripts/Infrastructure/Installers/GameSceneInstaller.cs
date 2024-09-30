using System.Collections.Generic;
using Enemies;
using HitPointsDamage;
using Infrastructure.Services;
using Items;
using Player;
using Player.ItemPicked;
using Plugins.Joystick.Scripts;
using UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private LifeBar _lifeBar;
        [SerializeField] private ExpPanel _expPanel;
        [SerializeField] private LevelUpMenu _levelUpMenu;
        [SerializeField] private PlayerDamageRecivier _playerDamageRecivier;
        [SerializeField] private ScreenInputHandler _screenInputHandler;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private ExpItem _expItemPrefab;
        [SerializeField] private StatsBar _statsBar;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private List<ItemConfig> _itemConfigs;
        
        private PlayerProvider _playerProvider;
        private PlayerStatsHolder _playerStatsHolder;

        public override void InstallBindings()
        {
            BindInputService();
            BindSaveLoadService();
            BindInventory();
            BindItemDatabase();
            BindPlayer();
            BindEffectReceiver();
            BindEnemyFactory();
            Container.BindInterfacesAndSelfTo<ExpHolder>().AsSingle().WithArguments(_playerStatsHolder).NonLazy();
            Container.Bind<LevelUpProcess>().AsSingle().WithArguments(_levelUpMenu).NonLazy();
            _expPanel.Set(_playerStatsHolder);
        }

        private void BindPlayer()
        {
            _playerStatsHolder = _playerConfig.GetNewPlayerData();
            //Container.Bind<PlayerStatsHolder>().FromInstance(_playerStatsHolder).AsSingle().NonLazy();
            _player.SetDataHolder(_playerStatsHolder);
            
            _playerProvider = new PlayerProvider(_player, _playerDamageRecivier);
            var damageApplier = new DamageApplier(_playerStatsHolder, _playerDamageRecivier);
            _lifeBar.SetDataHolder(_playerStatsHolder);
            _statsBar.SetDataHolder(_playerStatsHolder);
        }

        private void BindEnemyFactory()
        {
            Container.BindInterfacesTo<EnemyFactory>().AsSingle().WithArguments(_enemyPrefab, _enemyConfig, _playerProvider).NonLazy();
            Container.BindInterfacesTo<EnemySpawner>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyDropSpawner>().AsSingle().WithArguments(_expItemPrefab).NonLazy();
        }

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
            Container.Bind<ItemEffectApplier>().AsSingle().WithArguments(_playerStatsHolder).NonLazy();
        }

        private void BindItemDatabase()
        {
            ItemDatabase itemDatabase = new ItemDatabase(_itemConfigs);
            Container.Bind<ItemDatabase>().FromInstance(itemDatabase).AsSingle().NonLazy();
        }
    }
}