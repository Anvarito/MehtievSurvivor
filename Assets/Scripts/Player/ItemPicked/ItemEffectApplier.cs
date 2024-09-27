using HitPointsDamage;
using Items;
using UnityEngine;

namespace Player.ItemPicked
{
    public class ItemEffectApplier
    {
        private readonly PlayerStatsHolder _playerStatsHolder;

        public ItemEffectApplier(PlayerStatsHolder playerStatsHolder)
        {
            _playerStatsHolder = playerStatsHolder;
        }
        
        public void ApplyWeapon(WeaponItemConfig weaponItemConfig)
        {
            Debug.Log($"Picked up {weaponItemConfig.Name}.");
        }

        public void ApplyStatsUp(StatItemConfig statItemConfig)
        {
            Debug.Log($"Picked up {statItemConfig.Name}, {statItemConfig.Description}");
            
            if (statItemConfig.StatType == EStatType.HP)
            {
                _playerStatsHolder.CurrentHP.value += statItemConfig.EffectAmount;
            }

            if (statItemConfig.StatType == EStatType.Speed)
            {
                _playerStatsHolder.Speed.value += statItemConfig.EffectAmount;
            }
        }

        public void ApplyExp(ExpItem expItem)
        {
            Debug.Log($"Gain the expirience.");
        }
    }
}