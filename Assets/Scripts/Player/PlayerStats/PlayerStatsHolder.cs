using Infrastructure.Extras;

public class PlayerStatsHolder : BaseStatsHolder
{
    public ReactiveProperty<float> Progress;
    public ReactiveProperty<int> Level;
    public ReactiveProperty<float> DamagePrcnt;
    public ReactiveProperty<float> CooldownPrcnt;
}