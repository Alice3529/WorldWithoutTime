
namespace Characters.Player
{
    public class PlayerHealth : Health
    {
        public override void DamageHealth(float damageHealth)
        {
            base.DamageHealth(damageHealth);
            if (this.currentHealth <= 0)
            {
                LevelCompletedDialog.LoseDialog().Forget();
                Destroy(this.gameObject);
            }
        }
    }
}
