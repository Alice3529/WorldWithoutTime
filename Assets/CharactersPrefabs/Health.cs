using UI;
using UnityEngine;

namespace Characters
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float healthAmount = 100;
        [SerializeField] private HealthBar healthBar = default;

        public float currentHealth { get; private set; }

        private void Start()
        {
            this.currentHealth = this.healthAmount;
        }

        public virtual void DamageHealth(float damageHealth)
        {
            this.currentHealth -= damageHealth;
            this.healthBar.UpdateBar(this.currentHealth / this.healthAmount);
        }
    }
}
