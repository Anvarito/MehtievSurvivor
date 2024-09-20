using UnityEngine.Serialization;

[System.Serializable]
public class PlayerStatsData
{
    [FormerlySerializedAs("Heal")] public int HP = 50;
    public int Speed = 20;
    public int Wisdom = 10;
    public int Strength = 40;
}