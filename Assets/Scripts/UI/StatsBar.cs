using TMPro;
using UnityEngine;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healText;
    [SerializeField] private TextMeshProUGUI _speedText;

    public void HealChange(int count)
    {
        _healText.text = "HP: " + count;
    }

    public void SpeedChange(int count)
    {
        _speedText.text = "Speed: " + count;
    }
}