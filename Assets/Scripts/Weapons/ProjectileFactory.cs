using System.Collections.Generic;
using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public class ProjectileFactory : MonoBehaviour
    {
        private Dictionary<BaseShell, ObjectPool<BaseShell>> _pools = new();

        public void RegisterPrefab(BaseShell prefab, int initialSize = 0)
        {
            if (!_pools.ContainsKey(prefab))
            {
                var newPool = new ObjectPool<BaseShell>(prefab.GetComponent<BaseShell>(), initialSize);
                _pools[prefab] = newPool;
            }
        }

        public BaseShell GetProjectile(BaseShell prefab)
        {
            if (_pools.TryGetValue(prefab, out ObjectPool<BaseShell> pool))
            {
                pool.Get(out BaseShell projectile);
                return projectile;
            }
            else
            {
                Debug.LogError($"Prefab {prefab.name} is not registered in the factory.");
                return null;
            }
        }

        public void ReleaseProjectile(BaseShell prefab, BaseShell shell)
        {
            if (_pools.TryGetValue(prefab, out ObjectPool<BaseShell> pool))
            {
                pool.Release(shell);
            }
            else
            {
                Debug.LogError($"Prefab {prefab.name} is not registered in the factory.");
            }
        }
    }
}