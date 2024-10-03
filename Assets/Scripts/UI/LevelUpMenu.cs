using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class LevelUpMenu : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public UnityAction OnPress;

        private void Awake()
        {
            _button.onClick.AddListener(Press);
            Close();
        }

        private void Press()
        {
            OnPress?.Invoke();
        }

        public async UniTask Open()
        {
            await UniTask.Delay(1000);
            _button.gameObject.SetActive(true);
            print(1111);
        }

        public void Close()
        {
            _button.gameObject.SetActive(false);
        }
    }
}