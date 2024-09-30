using Items;
using UI;
using UnityEngine;

namespace Player.ItemPicked
{
    public class ItemEffectApplier
    {
        private readonly PlayerStatsHolder _playerStatsHolder;
        private readonly ExpHolder _expHolder;

        public ItemEffectApplier(PlayerStatsHolder playerStatsHolder, ExpHolder expHolder)
        {
            _playerStatsHolder = playerStatsHolder;
            _expHolder = expHolder;
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
            _expHolder.EncreaseExp(expItem.Points);
        }
    }
}