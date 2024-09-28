using System;
using System.Linq;
using Configs.Items;
using Enemies;
using Items;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Infrastructure.Services
{
    public class EnemyDropSpawner : IInitializable, IDisposable
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly ExpItem _expItem;
        private ObjectPool<ExpItem> _expPool;
        private GameObject _root;

        public EnemyDropSpawner(IEnemyFactory enemyFactory, ExpItem expItem)
        {
            _enemyFactory = enemyFactory;
            _expItem = expItem;
        }

        public void Initialize()
        {
            _expPool = new ObjectPool<ExpItem>(_expItem, 0);
            _enemyFactory.OnEnemyDead += EnemyDead;
            _root = new GameObject("DROP ITEMS");
            _root.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        public void Dispose()
        {
            _enemyFactory.OnEnemyDead -= EnemyDead;
        }

        protected virtual void EnemyDead(Enemy enemy)
        {
            var dropItems = enemy.StatsHolder.DropItems;
            if (dropItems == null || dropItems.Count == 0)
                return;

            float randomValue = Random.Range(0f, 100f);
            float currentSum = 0f;

            foreach (var item in dropItems)
            {
                currentSum += item.dropChance;
                if (randomValue <= currentSum)
                {
                    CreateExpItem(enemy.transform.position, item.expConfig);
                    return;
                }
            }
        }

        private void CreateExpItem(Vector3 position, ExpData data)
        {
            ExpItem expItem;
            bool isNew = _expPool.Get(out expItem);
            if (isNew)
            {
                expItem.transform.SetParent(_root.transform);
                expItem.OnPick += item => { _expPool.Release(expItem); };
            }

            expItem.SetPoints(data.ItemImage, data.ExpCount);
            expItem.transform.position = position;
        }
    }
}