using System;
using UniRx;

namespace GearSytem
{
    public class GearSystem
    {
        private int maxGearAmount = 5;

        private ReactiveProperty<int> gearAmount = default;
        public IReadOnlyReactiveProperty<int> GearAmount => this.gearAmount;

        public event Action OnGearsCollected = default;

        public GearSystem()
        {
            this.gearAmount = new ReactiveProperty<int>(0);
        }

        public void AddGear()
        {
            this.gearAmount.Value++;

            if (this.gearAmount.Value >= this.maxGearAmount)
            {
                this.OnGearsCollected?.Invoke();
            }
        }

        public void Reset()
        {
            this.gearAmount.Value = 0;
        }
    }
}
