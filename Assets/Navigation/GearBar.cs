using TMPro;
using UnityEngine;
using UniRx;

public class GearBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gearBar = default;
    private float gearAmount = 5; 

    private void Start()
    {
        Game.Instance.GearSystem.gearAmountProperty
            .Subscribe(UpdateGearBar)
            .AddTo(this); 
    }

    private void UpdateGearBar(int val)
    {
        this.gearBar.text = val.ToString() + "/" + this.gearAmount;
    }
}
