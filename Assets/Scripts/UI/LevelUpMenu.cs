using Items;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class LevelUpMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private LevelUpRewardClaimButton _button1;
        [SerializeField] private LevelUpRewardClaimButton _button2;
        [SerializeField] private LevelUpRewardClaimButton _button3;
        public UnityAction<ItemConfig> OnPress;

        private void Awake()
        {
            _button1.OnClick += Press;
            _button2.OnClick += Press;
            _button3.OnClick += Press;
            Close();
        }

        private void Press(ItemConfig item)
        {
            OnPress?.Invoke(item);
        }

        public void  Open()
        {
            _panel.SetActive(true);
        }

        public void Close()
        {
            _panel.SetActive(false);
        }
    }
}