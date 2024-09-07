using System.Collections.Generic;
using Items;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private List<ItemConfig> _itemConfigs;
    public override void InstallBindings()
    {
        BindInventorySaveLoader();
        BindItemDatabase();
    }

    private void BindInventorySaveLoader() =>
        Container.Bind<InventorySaveLoader>().AsSingle().NonLazy();

    private void BindItemDatabase()
    {
        ItemDatabase itemDatabase = new ItemDatabase(_itemConfigs);
        Container.Bind<ItemDatabase>().FromInstance(itemDatabase).AsSingle().NonLazy();
    }
}
