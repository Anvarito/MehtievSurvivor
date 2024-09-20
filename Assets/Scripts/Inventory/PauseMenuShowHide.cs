using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseMenuShowHide : MonoBehaviour
{
    [FormerlySerializedAs("_inventoryView")] [SerializeField] private GameObject _pausePanel;
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