using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventorySlotView : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private GameObject _counter;
    [SerializeField] private TextMeshProUGUI _itemCountView;

    private Button _button;
    public UnityAction OnClick;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
    }

    private void Click()
    {
        OnClick?.Invoke();
    }

    public void SetImage(Sprite sprite)
    {
        _itemImage.sprite = sprite;
    }

    public void SetCount(int count)
    {
        _itemImage.gameObject.SetActive(count > 0);
        _counter.SetActive(count > 0);
        _itemCountView.text = count.ToString();
    }
}