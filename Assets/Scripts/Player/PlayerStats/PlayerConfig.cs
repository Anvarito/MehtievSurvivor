using Infrastructure.Extras;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player configs/PlayerConfig")]
public class PlayerConfig : DefaultUnitConfig
{
    public PlayerStatsHolder GetNewPlayerData()
    {
        return new PlayerStatsHolder
        {
            MaxHP = new ReactiveProperty<float>(MaxHP),
            Speed = new ReactiveProperty<float>(MoveSpeed),
            CurrentHP = new ReactiveProperty<float>(MaxHP)
        };
    }
}