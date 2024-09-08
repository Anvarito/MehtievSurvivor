using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryShowHide : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryView;
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
        _inventoryView.SetActive(false);
    }

    private void Click()
    {
        _inventoryView.SetActive(!_inventoryView.activeSelf);
    }
}