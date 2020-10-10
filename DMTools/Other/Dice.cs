using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Other
{
    [Serializable]
    public struct Dice
    {
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        private static Random Rand { get; set; } = new Random();

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public byte Throws { get; private set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public byte Type { get; private set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public sbyte Extra { get; private set; }

        public Dice(Dice other) :
            this(other.Throws, other.Type, other.Extra)
        { }
        public Dice(byte throws, byte type) :
            this(throws, type, 0)
        { }
        public Dice(byte throws, byte type, sbyte extra)
        {
            Throws = throws;
            Type = type;
            Extra = extra;
        }
        public Dice(string th)
        {
            string[] separated = th.Split(new char[] { 'd', '+', '-' });
            Throws = Byte.Parse(separated[0]);
            Type = Byte.Parse(separated[1]);
            Extra = SByte.Parse(separated[2]);
        }
        public static int Throw(string th)
        {
            return new Dice(th).Throw();
        }
        public int Throw()
        {
            int total = 0;
            for (byte i = Throws; i >= 0; i--)
            {
                total += Rand.Next(1, Type);
            };
            return total + Extra;
        }

        public Dice Add(Dice other)
        {
            if (Type == other.Type)
            {
                return new Dice((byte)(Throws + other.Throws), Type, Extra);
            }
            else
            {
                throw new InvalidOperationException("Attempted to Add two Die of different types");
            }
        }
        public Dice Add(byte value)
        {
            return new Dice((byte)(Throws + value), Type, Extra);
        }

        public Dice Sub(byte value)
        {
            if (Throws > value)
            {
                return new Dice(1, Type, Extra);
            }
            else
            {
                return new Dice((byte)(Throws - value), Type, Extra);
            }
        }

        public string ThrowString
        {
            get
            {
                const string str1 = "{0}d{1}+{2}", str2 = "{0}d{1}{2}", str3 = "{0}d{1}";
                if (Extra > 0)
                {
                    return String.Format(str1, Throws, Type, Extra);
                }
                if (Extra < 0)
                {
                    return String.Format(str2, Throws, Type, Extra);
                }
                return String.Format(str3, Throws, Type);
            }
            set
            {
                this = new Dice(value);
            }
        }
    }
}
