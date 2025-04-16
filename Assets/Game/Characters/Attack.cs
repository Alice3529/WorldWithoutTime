using Characters;
using System.Linq;
using UnityEngine;

namespace Characters
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private Transform attackPoint = default;
        [SerializeField] private float damageAmount = 50;
        [SerializeField] private float attackRadius = 1f;
        [SerializeField] private string attackObjectTag = default;

        public void Damage()
        {
            Collider2D attackObjectCollider = Physics2D.OverlapCircleAll(this.attackPoint.position, this.attackRadius)
                .FirstOrDefault(collider => collider.CompareTag(this.attackObjectTag));

            if (attackObjectCollider != null)
            {
                Health health = attackObjectCollider.GetComponent<Health>();
                health.DamageHealth(this.damageAmount);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.attackPoint.position, this.attackRadius);
        }
    }
}
