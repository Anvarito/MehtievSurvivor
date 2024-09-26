using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Player", menuName = "PlayerConfigs/PlayerStats")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _hp = 100;
    [SerializeField] private float _speed = 10;
    
    public PlayerStatsData GetPlayerData()
    {
        return new PlayerStatsData
        {
            HP = _hp,
            Speed = _speed
        };
    }
}
[System.Serializable]
public class PlayerStatsData
{
    public float HP;
    public float Speed;
}