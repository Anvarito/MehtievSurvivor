using TMPro;
using UnityEngine;

namespace UI
{
    public class ExpPanel : MonoBehaviour
    {
        [SerializeField] private Material _lineMaterial;
        [SerializeField] private TextMeshProUGUI _levelText;

        private readonly int _slide = Shader.PropertyToID("_Slide");
        private PlayerStatsHolder _playerStatsHolder;

       // [Inject]
        public void Construct(PlayerStatsHolder playerStatsHolder)
        {
            _playerStatsHolder = playerStatsHolder;
        }

        public void Set(PlayerStatsHolder playerStatsHolder)
        {
            _playerStatsHolder = playerStatsHolder;
        }

        private void Awake()
        {
            _playerStatsHolder.Level.Changed += LevelChanged;
            _playerStatsHolder.Progress.Changed += ProgressChanged;
            
            ProgressChanged(0);
            LevelChanged(0);
        }

        private void OnDestroy()
        {
            _playerStatsHolder.Level.Changed -= LevelChanged;
            _playerStatsHolder.Progress.Changed -= ProgressChanged;
        }

        private void ProgressChanged(float alpha)
        {
            _lineMaterial.SetFloat(_slide, alpha);
        }

        private void LevelChanged(int level)
        {
            _levelText.text = $"LVL: {level}";
        }
    }
}