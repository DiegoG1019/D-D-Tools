using System;
using System.Collections.Generic;


namespace DMTools
{

    public struct Version
    {

        private readonly string preppendix;
        private readonly byte[] v;
        public Version(string p, byte w, byte z, byte y, byte x)
        {
            this.v = new byte[4];
            this.v[0] = w;
            this.v[1] = z;
            this.v[2] = y;
            this.v[3] = x;
            this.preppendix = p;
        }
        public string Full
        {
            get
            {
                return String.Format("{0}-{1}.{2}.{3}.{4}", this.preppendix, this.v[0], this.v[1], this.v[2], this.v[3]);
            }
        }
        public string Preppendix
        {
            get
            {
                return preppendix;
            }
        }
        public byte Major
        {
            get
            {
                return v[0];
            }
        }
        public byte Release
        {
            get
            {
                return v[1];
            }
        }
        public byte Addition
        {
            get
            {
                return v[2];
            }
        }
        public byte Minor
        {
            get
            {
                return v[3];
            }
        }

    }

    public interface IHistoried<T>
    {

        T GetHistory(int i);
        int HistoryEntries { get; }

    }

    public interface IFlagged<T>
    {

        bool GetFlag(T i);

    }

    public struct Dice
    {

        private static dynamic rand = new Random();
        private byte throws;
        private byte type;
        private sbyte extra;

        public Dice(byte throws, byte type)
        {
            this.throws = throws;
            this.type = type;
            this.extra = 0;
        }
        public Dice(byte throws, byte type, sbyte extra)
        {
            this.throws = throws;
            this.type = type;
            this.extra = extra;
        }
        public int throwDice()
        {

            int total = 0;

            for (byte i = this.throws; i > 0; i--)
            {
                total += Dice.rand.Next(1, this.type + 1);
            };

            return total + this.extra;

        }

        public Dice Add(Dice other)
        {
            if (this.type == other.type)
            {
                return new Dice((byte)(this.throws + other.throws), this.type, this.extra);
            }
            else
            {
                throw new TypeMismatchException("Attempted to Add two Die of different types");
            }
        }
        public Dice Add(byte value)
        {
            return new Dice((byte)(this.throws + value), this.type, this.extra);
        }

        public Dice Sub(byte value)
        {
            if (this.throws > value)
            {
                return new Dice(1, this.type, this.extra);
            }
            else
            {
                return new Dice((byte)(this.throws - value), this.type, this.extra);
            }
        }

        public string toString()
        {
            const string str1 = "{0}d{1}+{2}", str2 = "{0}d{1}{2}", str3 = "{0}d{1}";
            if (this.extra > 0)
            {
                return String.Format(str1, this.throws, this.type, this.extra);
            }
            else
            {
                if (this.extra < 0)
                {
                    return String.Format(str2, this.throws, this.type, this.extra);
                }
                else
                {
                    return String.Format(str3, this.throws, this.type);
                }
            }
        }

    }

    public struct PriceTag
    {
        private ulong value;

        public PriceTag(ulong v)
        {
            this.value = v;
        }

        public ulong get()
        {
            return this.value;
        }

        public void set(ulong v)
        {
            this.value = v;
        }

        public void change(int v)
        {
            this.value = (ulong)((int)this.value + v);
        }

        ///And finally, here's the reason I made this in the first place
        public string toString()
        {
            return String.Format("{0}{1}", Cf.Lang.util["currency"], this.value);
        }

    }

    public struct Wallet : IHistoried<int>
    {

        private ulong value;
        private readonly List<int> history;

        public Wallet(ulong value)
        {
            this.history = new List<int>();
            this.value = value;
            this.history.Add((int)value);
        }

        public float Weight
        {
            get
            {
                if (this.value > 0)
                {
                    return this.value / 50F;
                }
                else
                {
                    return 0F;
                }
            }
        }

        public void Add(ulong value)
        {
            this.value += value;
        }

        public void gain(ulong value)
        {
            this.Add(value);
            this.history.Add(((int)value));
        }
        public void gain(Wallet other)
        {
            this.Add(other.value);
            other.empty();
            this.history.Add(((int)value));
        }

        public void Sub(ulong value)
        {
            if (value > this.value)
            {
                throw new WalletOverDrawException(String.Format("Attempted to draw {0} over limit. W1:{1} ; w2:{2}", value - this.value, this.value, value));
            }
            else
            {
                this.value -= value;
            }
        }

        public void spend(ulong value)
        {
            this.Sub(value);
            this.history.Add(-((int)value));
        }
        public void spend(Wallet other)
        {
            this.Sub(other.value);
            this.history.Add(-((int)other.value));
        }

        public void empty()
        {
            this.spend(this.value);
        }

        public ulong Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (this.value > value)
                {
                    this.spend(this.value - value);
                }
                else
                {
                    if (this.value < value) //I don't want it to be added to the History if they were the same
                    {
                        this.gain(value - this.value);
                    }
                }
            }
        }
        public int GetHistory(int i)
        {
            return this.history[i];
        }

        public int HistoryEntries
        {
            get
            {
                return this.history.Count;
            }
        }

        public string toString()
        {
            return String.Format("{0}{1}", Cf.Lang.util["currency"], this.value);
        }

        public Wallet separate(ulong value)
        {
            this.spend(value);
            return new Wallet(value);
        }

    }

}