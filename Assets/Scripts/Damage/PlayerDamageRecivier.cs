namespace Damage
{
    public class PlayerDamageRecivier : DamageRecivier
    {
        public void ApplyDamage(float amount)
        {
            ApplyDamageInternal(amount);
        }
    }
}