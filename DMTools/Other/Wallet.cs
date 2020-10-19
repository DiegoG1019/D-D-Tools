using DiegoG.DnDTDesktop.Properties;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DiegoG.DnDTDesktop.Other
{
    [Serializable]
    public class Wallet : IHistoried
    {
        private int _Value;
        public ObservableCollection<int> History { get; set; } = new ObservableCollection<int>();
        public Mass Weight { get; private set; } = new Mass(0, Mass.Units.Kilogram);
        public void Add(int value)
        {
            _Value += value;
            Weight.Pound = _Value * Settings.Default.CoinWeight;
        }

        public void Gain(int value)
        {
            Add(value);
            History.Add(value);
        }
        public void Gain(Wallet other)
        {
            Add(other.Value);
            other.Empty();
            History.Add(_Value);
        }

        public void Sub(int value)
        {
            if (value > _Value)
                throw new InvalidOperationException($"Attempted to draw {value - Value}, over limit. W1: {Value}; W2: {value}");
            else
                _Value -= value;
            Weight.Pound = value * Settings.Default.CoinWeight;
        }

        public void Spend(int value)
        {
            Sub(value);
            History.Add(-value);
        }
        public void Spend(Wallet other)
        {
            Sub(other._Value);
            History.Add(-other._Value);
        }

        public void Empty()
        {
            History.Add(-Value);
            Value = 0;
        }

        public int Value
        {
            get => _Value;
            set
            {
                if (Value > value)
                {
                    Spend(Value - value);
                    return;
                }
                if (Value < value) //I don't want it to be added to the History if they were the same
                    Gain(value - Value);
            }
        }

        public PriceTag PriceTag => new PriceTag(Value);
        public Wallet() { }
        public Wallet(int value) : this() => Value = value;
        public override string ToString() => $"{Resources.Currency}{Value}";
        public Wallet Separate(int value)
        {
            Spend(value);
            return new Wallet(value);
        }
        public (Wallet Wallet, bool Uneven) Divide()
        {
            bool uneven = (Value % 2) > 0;
            int r = Value / 2;
            return (Separate(r), uneven);
        }
        public (List<Wallet> Wallets, bool Uneven) Divide(int parts)
        {
            bool uneven = (Value % parts) > 0;
            int val = Value / parts;
            (List<Wallet> Wallets, bool Uneven) ret = (new List<Wallet>(), uneven);
            for(; parts > 1; parts--)
                ret.Wallets.Add(Separate(val));
            return ret;
        }
    }
}
