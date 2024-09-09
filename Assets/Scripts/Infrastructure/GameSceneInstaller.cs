using System.Collections.Generic;
using Items;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private StatsBar _statsBar;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<ItemConfig> _itemConfigs;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();
        BindEffectReceiver();
        BindInventorySaveLoader();
        BindItemDatabase();
    }

    private void BindEffectReceiver()
    {
        PlayerStatsData playerStatsData = new PlayerStatsData();
        ItemReceiver itemReceiver = new ItemReceiver(_inventory, _statsBar, playerStatsData);
    }

    private void BindInventorySaveLoader() =>
        Container.Bind<InventorySaveLoader>().AsSingle().NonLazy();

    private void BindItemDatabase()
    {
        ItemDatabase itemDatabase = new ItemDatabase(_itemConfigs);
        Container.Bind<ItemDatabase>().FromInstance(itemDatabase).AsSingle().NonLazy();
    }
}
