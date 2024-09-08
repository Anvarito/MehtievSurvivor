using TMPro;
using UnityEngine;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healText;
    [SerializeField] private TextMeshProUGUI _speedText;
    [SerializeField] private TextMeshProUGUI _strengthText;
    [SerializeField] private TextMeshProUGUI _wisdomText;
    

    public void HealChange(int count)
    {
        _healText.text = "HP: " + count;
    }

    public void SpeedChange(int count)
    {
        _speedText.text = "Speed: " + count;
    }

    public void StregthChange(int count)
    {
        _strengthText.text = "Strength: " + count;
    }

    public void WisdomChange(int count)
    {
        _wisdomText.text = "Wisdom: " + count;
    }
}