using Enemies;
using Infrastructure.Services;
using Items;
using Scenarios;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private ExpItem _expItemPrefab;
        [SerializeField] private SpawnSequence _spawnSequence;
        public override void InstallBindings()
        {
            BindEnemyFactory();
        }
        private void BindEnemyFactory()
        {
            Container.BindInterfacesTo<EnemyPoolHolder>().AsSingle();
            Container.Bind<SpawnSequence>().FromInstance(_spawnSequence).AsSingle();
            Container.BindInterfacesTo<EnemyFactory>().AsSingle();
            Container.BindInterfacesTo<EnemySpawner>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyDropSpawner>().AsSingle().WithArguments(_expItemPrefab).NonLazy();
            Container.BindInterfacesTo<WaveChanger>().AsSingle();
        }
    }
}