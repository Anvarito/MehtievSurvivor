using TMPro;
using UnityEngine;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healText;
    [SerializeField] private TextMeshProUGUI _speedText;

    public void HealChange(float count)
    {
        _healText.text = "HP: " + count;
    }

    public void SpeedChange(float count)
    {
        _speedText.text = "Speed: " + count;
    }
}