using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class PauseMenuShowHide : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Click);
            _pausePanel.SetActive(false);
        }

        private void Click()
        {
            _pausePanel.SetActive(!_pausePanel.activeSelf);
        }
    }
}