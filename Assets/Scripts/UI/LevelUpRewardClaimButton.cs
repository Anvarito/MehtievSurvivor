using Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelUpRewardClaimButton : MonoBehaviour
{
    public ItemConfig _itemConfig;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _image;
    private Button _button;
    public UnityAction<ItemConfig> OnClick;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
        SetWeapon(_itemConfig);
    }

    public void SetWeapon(ItemConfig weaponConfig)
    {
        _itemConfig = weaponConfig;
        _image.sprite = _itemConfig.Image;
        _name.text = weaponConfig.Name;
        _description.text = weaponConfig.Description;
    }

    private void Click()
    {
        OnClick?.Invoke(_itemConfig);
    }
}
