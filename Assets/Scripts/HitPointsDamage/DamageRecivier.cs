using System;
using UnityEngine;
using UnityEngine.Events;

namespace Damage
{
    public class DamageRecivier : MonoBehaviour
    {
        public UnityAction<float> OnDamage;
        public virtual void ApplyDamage(float amount)
        {
            OnDamage?.Invoke(amount);
        }

        private void Start()
        {
            
        }
    }
}