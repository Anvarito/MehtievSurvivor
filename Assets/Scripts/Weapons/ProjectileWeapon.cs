using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public abstract class ProjectileWeapon<T> : BaseWeapon where T : BaseShell
    {
        [SerializeField] private BaseShell _shellPrefab;
        
        protected ObjectPool<BaseShell> _pool;
        protected Camera _camera;

        private void Awake()
        {
           
            _camera = Camera.main;
            _pool = new ObjectPool<BaseShell>(_shellPrefab, 0);
        }

        protected override void Launch()
        {
            T projectile;
            bool isNew = _pool.Get(out projectile);
            projectile.transform.position = transform.position;
            projectile.gameObject.SetActive(true);
            if (isNew)
            {
                projectile.OnShellDestroy += () => { ReleaseProjectile(projectile); };
            }

            InitProjectile(projectile);
        }

        private void ReleaseProjectile(BaseShell shell)
        {
            shell.Dispose();
            _pool.Release(shell);
        }
        protected abstract void InitProjectile(T projectile);
    }
}