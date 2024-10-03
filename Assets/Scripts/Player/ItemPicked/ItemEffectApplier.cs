using Items;
using UI;
using UnityEngine;

namespace Player.ItemPicked
{
    public class ItemEffectApplier
    {
        private readonly PlayerStatsHolder _playerStatsHolder;
        private readonly ExpAccumulator _expAccumulator;

        public ItemEffectApplier(PlayerStatsHolder playerStatsHolder, ExpAccumulator expAccumulator)
        {
            _playerStatsHolder = playerStatsHolder;
            _expAccumulator = expAccumulator;
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
            _expAccumulator.EncreaseExp(expItem.Points);
        }
    }
}