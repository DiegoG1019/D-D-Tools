using System;
using System.Collections.Generic;

namespace DnDTDesktop
{
    public class Items
    {
        /*-------------------------Sub Class Declaration-------------------------*/
        public struct Damage
        {
            public Dice Small { get; set; }
            public Dice Medium { get; set; }
            public Dice Big { get; set; }
        }

        public struct DamageThrow
        {
            public string DamageType { get; set; }
            public Stats KeyStat { get; set; }
            public Stats? SecondaryStat { get; set; }
        }

        public struct CriticalHit
        {
            public byte Minimum { get; set; }
            public byte Maximum { get; set; }
            public float Multiplier { get; set; }
            public string Value
            {
                get
                {
                    if (Maximum != Minimum)
                    {
                        return String.Format("{0}-{1}; x{2}", Minimum, Maximum, Multiplier);
                    }
                    else
                    {
                        return String.Format("{0}; x{1}", Minimum, Multiplier);
                    }
                }
            }
            public CriticalHit(byte Min, byte Max, byte Mult)
            {
                Minimum = Min;
                Maximum = Max;
                Multiplier = Mult;
            }
            public CriticalHit(byte Min, byte Mult)
            {
                Minimum = Min;
                Maximum = Min;
                Multiplier = Mult;
            }
        }

        /*------------------------- -------------------------*/
    }

}
