using Serilog;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace DiegoG.DnDNetCore.Other
{
    [Serializable]
    public struct Dice
    {
        public string ThrowString
        {
            get
            {
                if (Extra > 0)
                    return $"{Throws}d{Type}+{Extra}";
                if (Extra < 0)
                    return $"{Throws}d{Type}{Extra}";
                return $"{Throws}d{Type}";
            }
            set => this = new Dice(value);
        }
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        private static Random Rand { get; set; } = new Random();

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Throws { get; set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Type { get; set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Extra { get; set; }

        public Dice(Dice other) :
            this(other.Throws, other.Type, other.Extra)
        { }
        public Dice(int throws, int type) :
            this(throws, type, 0)
        { }
        public Dice(int throws, int type, int extra)
        {
            Throws = throws;
            Type = type;
            Extra = extra;
        }
        public Dice(string th)
        {
            Validate(th);
            var sep = Regex.Matches(th, @"[\+\-]?\d+");
            if (!(sep.Count == 2 || sep.Count == 3))
                invalidstring(th);
            Throws = int.Parse(sep[0].Value);
            Type = int.Parse(sep[1].Value);
            Extra = int.Parse(sep.Count > 2 ? sep[2].Value : "0");
        }
        private const string ValidationPattern = @"\d+d\d+([\+\-]?\d+)?";
        public static bool ValidateString(string str) => Regex.Match(str, ValidationPattern).Success;
        private static void Validate(string str)
        {
            if (!ValidateString(str))
                invalidstring(str);
        }
        private static void invalidstring(string str) => throw new ArgumentException($"The given string \"{str}\" is not valid for Dice");
        public static int Throw(string th) => new Dice(th).Throw();
        public int Throw()
        {
            int total = 0;
            for (int i = 0; i < Throws; i++)
            {
//#warning Only for C# interactive
//                Console.WriteLine($"Throws: {Throws} | Type: {Type} | Extra: {Extra} | ThrowIndex: {i}"); //ONLY FOR C# INTERACTIVE
                total += Rand.Next(1, Type);
            }
            return total + Extra;
        }

        public Dice Add(Dice other)
        {
            if (Type == other.Type)
                return new Dice(Throws + other.Throws, Type, Extra);
            else
                throw new InvalidOperationException("Attempted to Add two Die of different types");
        }
        public Dice Add(int value) => new Dice(Throws + value, Type, Extra);
        public Dice Sub(int value)
        {
            if (Throws > value)
                return new Dice(1, Type, Extra);
            else
                return new Dice(Throws - value, Type, Extra);
        }

        public static Dice NoDice { get; } = new Dice("0d0");
    }
}
