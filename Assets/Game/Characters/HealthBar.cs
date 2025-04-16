using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image bar = default;

        public void UpdateBar(float fillAmount)
        {
            if (fillAmount == 0) { this.gameObject.SetActive(false); }
            this.bar.fillAmount = fillAmount;
        }
    }
}
