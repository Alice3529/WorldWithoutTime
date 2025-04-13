using Characters;
using System.Linq;
using UnityEngine;

namespace Charcter
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private Transform attackPoint = default;
        [SerializeField] private float damageAmount = 50;
        [SerializeField] private float sphereRadius = 1f;
        [SerializeField] private string tag = default;

        public void Damage()
        {
            Collider2D playerCollider = Physics2D.OverlapCircleAll(this.attackPoint.position, 2f)
                .FirstOrDefault(x => x.gameObject.tag == this.tag);

            if (playerCollider != null)
            {
                playerCollider.GetComponent<Health>().DamageHealth(this.damageAmount);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(this.attackPoint.position, this.sphereRadius);
        }
    }
}
