using HitPointsDamage;
using UnityEngine;

namespace Player
{
    public class PlayerProvider
    {
        public Transform PlayerTransform { get; private set; }
        private readonly PlayerMovement _playerMovement;
        public PlayerDamageRecivier PlayerDamageRecivier { get; private set; }

        public PlayerProvider(PlayerMovement playerMovement, PlayerDamageRecivier playerDamageRecivier)
        {
            _playerMovement = playerMovement;
            PlayerDamageRecivier = playerDamageRecivier;
            PlayerTransform = playerMovement.transform;
        }
    }
}