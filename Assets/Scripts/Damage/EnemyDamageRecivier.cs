namespace Damage
{
    public class EnemyDamageRecivier : DamageRecivier
    {
        public void ApplyDamage(float amount)
        {
            ApplyDamageInternal(amount);
        }
    }
}