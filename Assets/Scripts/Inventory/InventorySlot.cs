using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private GameObject _counter;
    [SerializeField] private TextMeshProUGUI _itemCountView;
    public UnityAction<InventorySlot> OnSlotClick;
    public int ItemCount { get; set; }
    public EItemType ItemType { get; set; }

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    public void InitSlot(EItemType type, int count)
    {
        ItemCount = count;
        ItemType = type;

        _itemCountView.text = ItemCount.ToString();
    }
    
    public void EncreaseItem()
    {
        ItemCount++;
        _itemCountView.text = ItemCount.ToString();
    }

    public void DecreaseItem()
    {
        ItemCount--;
        _itemCountView.text = ItemCount.ToString();
        if (ItemCount == 0)
        {
            SetDefaultView();
        }
    }

    private void SetDefaultView()
    {
        ItemType = EItemType.None;
        _counter.SetActive(false);
        _itemImage.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (ItemCount > 0)
        {
            DecreaseItem();
            OnSlotClick?.Invoke(this);
        }
    }
}