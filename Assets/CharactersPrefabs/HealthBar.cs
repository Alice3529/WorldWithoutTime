using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void UpdateBar(float fillAmount)
        {
            if (fillAmount == 0) { this.gameObject.SetActive(false); }
            this.image.fillAmount = fillAmount;
        }
    }
}
