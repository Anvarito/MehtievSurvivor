using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Extras
{
    public class MonobehPool<T> where T : MonoBehaviour
    {
        private readonly T prefab;
        private readonly Queue<T> objects = new();

        public MonobehPool(T prefab, int initialSize)
        {
            this.prefab = prefab;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = Object.Instantiate(prefab);
                obj.gameObject.SetActive(false);
                objects.Enqueue(obj);
            }
        }

        public bool Get<T>(out T obj) where T : MonoBehaviour
        {
            if (objects.Count > 0)
            {
                obj = objects.Dequeue() as T;
                obj.gameObject.SetActive(true);
                return false;
            }

            obj = Object.Instantiate(prefab) as T;
            return true;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
            objects.Enqueue(obj);
        }
    }
}