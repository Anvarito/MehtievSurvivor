using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Services
{
    public class GameObjectLoader
    {
        private GameObject _cachedObject;
        
        protected async UniTask<T> LoadInternal<T>(string assetId, Transform parent = null) where T : class
        {
            var handle = Addressables.InstantiateAsync(assetId, parent);
            _cachedObject = await handle.Task;
            if (typeof(T) == typeof(GameObject))
                return _cachedObject as T;
            if(_cachedObject.TryGetComponent(out T component) == false)
                throw new NullReferenceException($"Object of type {typeof(T)} is null on " +
                                                 "attempt to load it from addressables");
            return component;
        }
        
        protected void UnloadInternal()
        {
            // if(_cachedObject == null)
            //     return;
            // _cachedObject.SetActive(false);
            // Addressables.ReleaseInstance(_cachedObject);
            // _cachedObject = null;
        }
        
    }
}