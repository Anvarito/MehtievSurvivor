using DG.Tweening;
using UnityEngine;

namespace Weapons
{
    public class RotateProjectile : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.5f;
        private void OnEnable()
        {
            transform.rotation = Quaternion.identity;
            transform.DORotate(new Vector3(0, 0, 360), _duration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }
    }
}