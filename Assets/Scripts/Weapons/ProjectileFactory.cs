using System.Collections.Generic;
using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public class ProjectileFactory : MonoBehaviour
    {
        private Dictionary<BaseProjectile, ObjectPool<BaseProjectile>> _pools = new();

        public void RegisterPrefab(BaseProjectile prefab, int initialSize = 0)
        {
            if (!_pools.ContainsKey(prefab))
            {
                var newPool = new ObjectPool<BaseProjectile>(prefab.GetComponent<BaseProjectile>(), initialSize);
                _pools[prefab] = newPool;
            }
        }

        public BaseProjectile GetProjectile(BaseProjectile prefab)
        {
            if (_pools.TryGetValue(prefab, out ObjectPool<BaseProjectile> pool))
            {
                pool.Get(out BaseProjectile projectile);
                return projectile;
            }
            else
            {
                Debug.LogError($"Prefab {prefab.name} is not registered in the factory.");
                return null;
            }
        }

        public void ReleaseProjectile(BaseProjectile prefab, BaseProjectile projectile)
        {
            if (_pools.TryGetValue(prefab, out ObjectPool<BaseProjectile> pool))
            {
                pool.Release(projectile);
            }
            else
            {
                Debug.LogError($"Prefab {prefab.name} is not registered in the factory.");
            }
        }
    }
}