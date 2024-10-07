using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public abstract class ProjectileWeapon<T> : BaseWeapon where T : BaseProjectile
    {
        [SerializeField] private BaseProjectile _prefab;
        
        protected ObjectPool<BaseProjectile> _pool;
        protected Camera _camera;

        protected override void Awake()
        {
            base.Awake();
            _camera = Camera.main;
            _pool = new ObjectPool<BaseProjectile>(_prefab, 0);
        }

        protected override void Launch()
        {
            T projectile;
            bool isNew = _pool.Get(out projectile);
            projectile.transform.position = transform.position;
            projectile.gameObject.SetActive(true);
            if (isNew)
            {
                projectile.OnDestroy += () => { ReleaseProjectile(projectile); };
            }

            InitProjectile(projectile);
        }

        private void ReleaseProjectile(BaseProjectile projectile)
        {
            projectile.Dispose();
            _pool.Release(projectile);
        }
        protected abstract void InitProjectile(T projectile);
    }
}