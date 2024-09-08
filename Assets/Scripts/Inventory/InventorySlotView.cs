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
        if (count > 0)
        {
            _itemImage.gameObject.SetActive(true);
            _counter.SetActive(true);
            _itemCountView.text = count.ToString();
        }
        else
        {
            _itemImage.gameObject.SetActive(false);
            _counter.SetActive(false);
        }
    }
}