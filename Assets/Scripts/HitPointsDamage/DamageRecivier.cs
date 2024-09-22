using UnityEngine;
using UnityEngine.Events;

namespace Damage
{
    public class DamageRecivier : MonoBehaviour
    {
        public UnityAction<float> OnDamage;
        protected void ApplyDamageInternal(float amount)
        {
            OnDamage?.Invoke(amount);
        }
    }
}