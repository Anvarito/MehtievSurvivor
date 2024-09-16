using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure.Services
{
    public class ExampleLoadProvider : GameObjectLoader
    {
        public async void LoadAndDestroy(UnityAction<GameObject> result)
        {
            var gm = await Load();
            result?.Invoke(gm);
            Unload();
        }
        
        public async UniTask<GameObject> Load()
        {
            return await LoadInternal<GameObject>("Hren");
        }

        public void Unload()
        {
            UnloadInternal();
        }
    }
}