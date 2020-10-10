using DiegoG.DnDTDesktop.Properties;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;

namespace DiegoG.DnDTDesktop.Other
{
    [Serializable]
    public class Wallet : IHistoried<long>
    {
        private CUInt32 value;
        public List<long> History { get; set; }

        public Mass Weight { get; private set; }
        public void Add(CUInt32 value)
        {
            this.value += value;
            Weight.Pound = this.value * Settings.Default.CoinWeight;
        }

        public void Gain(CUInt32 value)
        {
            Add(value);
            History.Add(value);
        }
        public void Gain(Wallet other)
        {
            Add(other.Value);
            other.Empty();
            History.Add(value);
        }

        public void Sub(CUInt32 value)
        {
            if (value > this.value)
            {
                throw new InvalidOperationException(String.Format("Attempted to draw {0} over limit. W1:{1} ; w2:{2}", value - Value, Value, value));
            }
            else
            {
                this.value -= value;
            }
            Weight.Pound = value * Settings.Default.CoinWeight;
        }

        public void Spend(CUInt32 value)
        {
            Sub(value);
            History.Add(-value);
        }
        public void Spend(Wallet other)
        {
            Sub(other.value);
            History.Add(-other.value);
        }

        public void Empty()
        {
            History.Add(-Value);
            Value = 0;
        }

        public CUInt32 Value
        {
            get
            {
                return value;
            }
            set
            {
                if (this.value > value)
                {
                    Spend(this.value - value);
                    return;
                }
                if (this.value < value) //I don't want it to be added to the History if they were the same
                {
                    Gain(value - this.value);
                }
            }
        }

        new public string ToString()
        {
            return String.Format("{0}{1}", Resources.Currency, Value);
        }

        public Wallet Separate(uint value)
        {
            Spend(value);
            return new Wallet()
            {
                Value = value
            };
        }
    }
}
