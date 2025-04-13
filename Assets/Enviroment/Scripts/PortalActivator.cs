using UnityEngine;

namespace Portal
{
    public class PortalActivator : MonoBehaviour
    {
        [SerializeField] private Portal portal = default;

        private void Start()
        {
            this.portal.gameObject.SetActive(false);
            Game.Instance.GearSystem.OnGearsCollected += ActivatePortal;
        }

        private void ActivatePortal()
        {
            this.portal.gameObject.SetActive(true);
        }
    }
}
