using System;
using UniRx;

public class GearSystem 
{
    private int currentGearAmount = default;
    private int maxGearAmount = 5;

    public ReactiveProperty<int> gearAmountProperty;

    public event Action OnGearsCollected = default;

    public GearSystem()
    {
        this.gearAmountProperty = new ReactiveProperty<int>(this.currentGearAmount);
    }

    public void AddGear()
    {
        this.currentGearAmount++;
        this.gearAmountProperty.Value = this.currentGearAmount;

        if (this.currentGearAmount >= this.maxGearAmount)
        {
            this.OnGearsCollected?.Invoke();
        }
    }
}
