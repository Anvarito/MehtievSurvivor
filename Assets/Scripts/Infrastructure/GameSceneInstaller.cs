using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InventorySaveLoader>().AsSingle().NonLazy();
    }
}
