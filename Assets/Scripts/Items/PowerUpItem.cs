namespace Items
{
    public class PowerUpItem : StatItem
    {
        protected override void ApplyEffect()
        {
            _itemApplier.ApplyPowerUp(_config);
            Destroy(gameObject);
        }
    }
}