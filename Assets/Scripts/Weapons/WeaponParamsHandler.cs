using Weapons;
using Weapons.Configs;

public class WeaponParamsHandler
{
    public WeaponConfig Config { get; }
    public int MaxLevel => Config.weaponUpgradeDatas.Count;
    public int CurrentLevel => _level + 1;

    private readonly BaseWeapon _baseWeapon;
    private readonly PlayerStatsHolder _playerStatsHolder;
    private WeaponParams _weaponParams;
    private int _level = -1;

    public WeaponParamsHandler(WeaponConfig config, BaseWeapon baseWeapon,
        PlayerStatsHolder playerStatsHolder)
    {
        _baseWeapon = baseWeapon;
        Config = config;
        _playerStatsHolder = playerStatsHolder;
        
        Initialize();
    }

    private void Initialize()
    {
        _weaponParams = new WeaponParams();
        ChangeTier();
        _baseWeapon.SetParams(_weaponParams);
    }

    public void ChangeTier()
    {
        _level++;
        var newTierParams = Config.weaponUpgradeDatas[_level];

        _weaponParams.DamageAmount =
            newTierParams.DamageAmount * (1 + _playerStatsHolder.DamagePrcnt.value / 100);
        _weaponParams.KnockAmount = newTierParams.KnockAmount;
        _weaponParams.Cooldown = newTierParams.Cooldown * (1 - _playerStatsHolder.CooldownPrcnt.value / 100);
        _weaponParams.LifeTime = newTierParams.LifeTime;
        _weaponParams.Speed = newTierParams.Speed;
    }
}