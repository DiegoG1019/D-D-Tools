using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System.Text.Json;
using Serilog;

namespace DnDTDesktop
{

    public static class SerializeToFile
    {
        public static string JsonFileExtension = ".json";
        public static void Json<T>(T obj, string path, string filename)
        {
            string fullpath = Path.Combine(path, filename + JsonFileExtension);

            Log.Verbose("Attempting to serialize Object of type {0} to JSON file {1}", typeof(T).ToString(), fullpath);

            string jsonstring = JsonSerializer.Serialize(obj, App.JSONOptions);

            Log.Verbose("Wrote {0} characters", jsonstring.Length);

            using (StreamWriter OutFile = new StreamWriter(new FileStream(fullpath, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                OutFile.WriteLine(jsonstring);
            }
        }
    }

    public static class DeserializeFromFile
    {
        public static T Json<T>(string path, string filename)
        {
            string fullpath = Path.Combine(path, filename + SerializeToFile.JsonFileExtension);

            Log.Verbose("Attempting to deserialize Object of type {0} from JSON file {1}", typeof(T).ToString(), fullpath);

            using (StreamReader InFile = new StreamReader(new FileStream(fullpath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                string jsonstring = InFile.ReadToEnd();

                Log.Verbose("Read {0} characters", jsonstring.Length);

                return JsonSerializer.Deserialize<T>(jsonstring);
            }
        }
    }

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
        public string Short
        {
            get
            {
                return String.Format("{0}.{1}.{2}.{3}",v[0],v[1],v[2],v[3]);
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
        public byte Minor
        {
            get
            {
                return v[2];
            }
        }
        public byte Addition
        {
            get
            {
                return v[1];
            }
        }

    }

    public interface IHistoried<T>
    {
        List<T> History { get; set; }

    }

    public interface IFlagged<T>
    {

        bool GetFlag(T i);

    }

    public struct Dice
    {

        [IgnoreDataMember]
        private readonly static dynamic rand = new Random();

        [IgnoreDataMember]
        [JsonIgnore]
        public byte Throws { get; private set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public byte Type { get; private set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public sbyte Extra { get; private set; }

        public Dice(byte throws, byte type)
        {
            this.Throws = throws;
            this.Type = type;
            this.Extra = 0;
        }
        public Dice(byte throws, byte type, sbyte extra)
        {
            this.Throws = throws;
            this.Type = type;
            this.Extra = extra;
        }
        public int ThrowDice()
        {

            int total = 0;

            for (byte i = this.Throws; i > 0; i--)
            {
                total += Dice.rand.Next(1, this.Type + 1);
            };

            return total + this.Extra;

        }

        public Dice Add(Dice other)
        {
            if (this.Type == other.Type)
            {
                return new Dice((byte)(this.Throws + other.Throws), this.Type, this.Extra);
            }
            else
            {
                throw new TypeMismatchException("Attempted to Add two Die of different types");
            }
        }
        public Dice Add(byte value)
        {
            return new Dice((byte)(this.Throws + value), this.Type, this.Extra);
        }

        public Dice Sub(byte value)
        {
            if (this.Throws > value)
            {
                return new Dice(1, this.Type, this.Extra);
            }
            else
            {
                return new Dice((byte)(this.Throws - value), this.Type, this.Extra);
            }
        }

        new public string ToString()
        {
            const string str1 = "{0}d{1}+{2}", str2 = "{0}d{1}{2}", str3 = "{0}d{1}";
            if (this.Extra > 0)
            {
                return String.Format(str1, this.Throws, this.Type, this.Extra);
            }
            else
            {
                if (this.Extra < 0)
                {
                    return String.Format(str2, this.Throws, this.Type, this.Extra);
                }
                else
                {
                    return String.Format(str3, this.Throws, this.Type);
                }
            }
        }

    }

    public struct PriceTag
    {
        [IgnoreDataMember]
        [JsonIgnore]
        public ulong Value { get; set; }

        public PriceTag(ulong v)
        {
            this.Value = v;
        }

        public void Add(int v)
        {
            Value = (ulong)((long)Value + v);
        }

        ///And finally, here's the reason I made this in the first place
        new public string ToString()
        {
            return String.Format("{0}{1}", App.Cf.Lang.Util["currency"], this.Value);
        }

    }

    public struct Wallet : IHistoried<int>
    {

        private ulong value;
        public List<int> History { get; set; }

        public Wallet(ulong value)
        {
            this.History = new List<int>();
            this.value = value;
            this.History.Add((int)value);
        }

        public float Weight
        {
            get
            {
                if (this.Value > 0)
                {
                    return this.Value / 50F;
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

        public void Gain(ulong value)
        {
            this.Add(value);
            this.History.Add(((int)value));
        }
        public void Gain(Wallet other)
        {
            this.Add(other.Value);
            other.Empty();
            this.History.Add(((int)value));
        }

        public void Sub(ulong value)
        {
            if (value > this.value)
            {
                throw new WalletOverDrawException(String.Format("Attempted to draw {0} over limit. W1:{1} ; w2:{2}", value - this.Value, this.Value, value));
            }
            else
            {
                this.value -= value;
            }
        }

        public void Spend(ulong value)
        {
            this.Sub(value);
            this.History.Add(-((int)value));
        }
        public void Spend(Wallet other)
        {
            this.Sub(other.value);
            this.History.Add(-((int)other.value));
        }

        public void Empty()
        {
            Value = 0;
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
                    this.Spend(this.value - value);
                }
                else
                {
                    if (this.value < value) //I don't want it to be added to the History if they were the same
                    {
                        this.Gain(value - this.value);
                    }
                }
            }
        }

        new public string ToString()
        {
            return String.Format("{0}{1}", App.Cf.Lang.Util["currency"], this.Value);
        }

        public Wallet Separate(ulong value)
        {
            this.Spend(value);
            return new Wallet(value);
        }

    }

}