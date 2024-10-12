using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Extras
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly T prefab;
        private readonly List<T> objects = new();

        public ObjectPool(T prefab, int initialSize)
        {
            this.prefab = prefab;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = Object.Instantiate(prefab);
                obj.gameObject.SetActive(false);
                objects.Add(obj);
            }
        }
        
        public bool Get(out T obj)
        {
            foreach (var pooledObj in objects)
            {
                if (!pooledObj.gameObject.activeSelf)
                {
                    obj = pooledObj;
                    obj.gameObject.SetActive(true);
                    return false;
                }
            }

            obj = Object.Instantiate(prefab);
            objects.Add(obj);
            return true;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
        }
        
        public int GetActiveCount()
        {
            int countAlive = 0;

            foreach (var obj in objects)
            {
                if (obj.gameObject.activeSelf)
                {
                    countAlive++;
                }
            }

            return countAlive;
        }
    }
}