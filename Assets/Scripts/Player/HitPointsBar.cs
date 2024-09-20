using UnityEngine;

namespace Player
{
    public class HitPointsBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _HPbar;
        private Material _material;
        private void Awake()
        {
            _material = _HPbar.material;
        }

        public void SetValue(float value)
        {
            _material.SetFloat("_Slide", value);
        }
    }
}