using Infrastructure.Extras;
using UnityEngine;

namespace Weapons
{
    public abstract class ProjectileWeapon<T> : BaseWeapon where T : BaseShell
    {
        [SerializeField] private T _shellPrefab;
        
        protected ObjectPool<T> _pool;
        protected Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _pool = new ObjectPool<T>(_shellPrefab, 0);
        }

        protected override void Launch()
        {
            T shell;
            bool isNew = _pool.Get(out shell);
            shell.transform.position = transform.position;
            shell.gameObject.SetActive(true);
            if (isNew)
            {
                shell.OnShellDestroy += () => { ReleaseProjectile(shell); };
            }

            InitProjectile(shell);
        }

        private void ReleaseProjectile(T shell)
        {
            shell.Dispose();
            _pool.Release(shell);
        }
        protected abstract void InitProjectile(T projectile);
    }
}