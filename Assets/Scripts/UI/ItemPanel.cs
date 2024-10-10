using System;
using Items;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[Serializable]
public class ItemBar
{
    [SerializeField] private Image _cellPrefab;
    [SerializeField] private Transform _bar;

    public void CreateCell(Sprite sprite)
    {
        var cell = Object.Instantiate(_cellPrefab, _bar);
        cell.gameObject.SetActive(true);
        cell.sprite = sprite;
    }
}
public class ItemPanel : MonoBehaviour
{
    [SerializeField] private ItemBar _weaponBar;
    [SerializeField] private ItemBar _effectBar;

    public void SetNewWeapon(WeaponItemConfig weaponItemConfig)
    {
        _weaponBar.CreateCell(weaponItemConfig.Image);
    }

    public void SetNewEffect(StatItemConfig statItemConfig)
    {
        _effectBar.CreateCell(statItemConfig.Image);
    }
}
