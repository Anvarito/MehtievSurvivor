using Infrastructure.Extras;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player configs/PlayerConfig")]
public class PlayerConfig : DefaultUnitConfig
{
    public int StartLevel = 0;
    public float Progress = 0;
    public PlayerStatsHolder GetNewPlayerData()
    {
        return new PlayerStatsHolder
        {
            MaxHP = new ReactiveProperty<float>(MaxHP),
            Speed = new ReactiveProperty<float>(MoveSpeed),
            CurrentHP = new ReactiveProperty<float>(MaxHP),
            Progress = new ReactiveProperty<float>(Progress),
            Level = new ReactiveProperty<int>(StartLevel)
        };
    }
}