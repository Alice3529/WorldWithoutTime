
namespace Characters.Enemy
{
    public class EnemyHealth : Health
    {
        public override void DamageHealth(float damageHealth)
        {
            base.DamageHealth(damageHealth);

            if (this.currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
