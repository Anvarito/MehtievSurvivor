using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Services;
using Items;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private StatsBar _statsBar;
        [SerializeField] private Inventory _inventoryPrefab;
        [SerializeField] private List<ItemConfig> _itemConfigs;

        public override void InstallBindings()
        {
            BindInputService();
            BindSaveLoadService();
            BindInventory();
            BindEffectReceiver();
            BindItemDatabase();

            ExampleLoad();
        }

        private void ExampleLoad()
        {
            ExampleLoadProvider exampleLoadProvider = new ExampleLoadProvider();
            exampleLoadProvider.LoadAndDestroy(LoadSomthing);
        }

        private void LoadSomthing(GameObject result)
        {
            print(result.gameObject.name);
        }

        private void BindSaveLoadService()
        {
            Container.Bind<SaveLoadService>().AsSingle().NonLazy();
            Container.Bind<StatsSaveLoader>().AsSingle().NonLazy();
            Container.Bind<InventorySaveLoader>().AsSingle().NonLazy();
        }

        private void BindInventory() =>
            Container.BindInterfacesTo<Inventory>().FromComponentInNewPrefab(_inventoryPrefab).AsSingle().NonLazy();

        private void BindInputService() =>
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();

        private void BindEffectReceiver()
        {
            PlayerStatsData playerStatsData = new PlayerStatsData();
            Container.Bind<ItemEffectReceiver>().AsSingle().WithArguments(_statsBar, playerStatsData).NonLazy();
        }

        private void BindItemDatabase()
        {
            ItemDatabase itemDatabase = new ItemDatabase(_itemConfigs);
            Container.Bind<ItemDatabase>().FromInstance(itemDatabase).AsSingle().NonLazy();
        }
    }
}