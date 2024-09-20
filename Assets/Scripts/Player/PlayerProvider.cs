using UnityEngine;

namespace Player
{
    public class PlayerProvider
    {
        public Transform PlayerTransform { get; private set; }
        private readonly PlayerMovement _playerMovement;

        public PlayerProvider(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
            PlayerTransform = playerMovement.transform;
        }
    }
}