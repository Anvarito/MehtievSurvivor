using Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUpRewardClaimButton : MonoBehaviour
{
    public ItemConfig _weaponConfig;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _image;
    private Button _button;
    public UnityAction<ItemConfig> OnClick;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
        SetWeapon(_weaponConfig);
    }

    public void SetWeapon(ItemConfig weaponConfig)
    {
        _weaponConfig = weaponConfig;
        _image.sprite = _weaponConfig.Image;
        _description.text = weaponConfig.Name;
    }

    private void Click()
    {
        OnClick?.Invoke(_weaponConfig);
    }
}
