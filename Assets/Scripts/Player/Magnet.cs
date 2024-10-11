using Items;
using UnityEngine;

namespace Player
{
    public class Magnet : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Magnetable magnetable))
            {
                if (!magnetable.IsPicked)
                    magnetable.StartMagnetItem(transform);
            }
        }
    }
}