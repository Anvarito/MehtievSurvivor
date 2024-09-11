using System.Collections.Generic;
using Items;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private StatsBar _statsBar;
        [SerializeField] private Inventory _inventoryPrefab;
        [SerializeField] private List<ItemConfig> _itemConfigs;
        public override void InstallBindings()
        {
            BindInventory();
            BindInputService();
            BindEffectReceiver();
            BindInventorySaveLoader();
            BindItemDatabase();
        }

        private void BindInventory() =>
            Container.BindInterfacesTo<Inventory>().FromComponentInNewPrefab(_inventoryPrefab).AsSingle().NonLazy();

        private void BindInputService() =>
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();

        private void BindEffectReceiver()
        {
            PlayerStatsData playerStatsData = new PlayerStatsData();
            Container.Bind<ItemReceiver>().AsSingle().WithArguments(_statsBar, playerStatsData).NonLazy();
        }

        private void BindInventorySaveLoader() =>
            Container.Bind<InventorySaveLoader>().AsSingle().NonLazy();

        private void BindItemDatabase()
        {
            ItemDatabase itemDatabase = new ItemDatabase(_itemConfigs);
            Container.Bind<ItemDatabase>().FromInstance(itemDatabase).AsSingle().NonLazy();
        }
    }
}
