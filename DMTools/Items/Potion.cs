using DiegoG.DnDTDesktop.Other;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTDesktop.Enumerations;

namespace DiegoG.DnDTDesktop.Items
{
    public class Potion : Item
    {
        public class Effect
        {
            public string Description { get; set; }
            public TimeSpan Duration { get; set; }  //Seconds
            public int[] Bonus { get; set; } = new int[Enumerations.StatCount];
            public int this[Stats index]
            {
                get
                {
                    return Bonus[(int)index];
                }
                set
                {
                    Bonus[(int)index] = value;
                }
            }
        }

        public List<Effect> Effects { get; set; } = new List<Effect>();
        public Percentage Fill { get; set; } = default;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public Percentage Solvent => new Percentage(100f - Fill.Value);

        private int[] AdjustBonus(Percentage OtherFill, int[] OtherBonus)
        {
            for (int i = 0; i < OtherBonus.Length; i++)
            {
                OtherBonus[i] = (int)(OtherBonus[i] * OtherFill.Percent);
            }
            return OtherBonus;
        }

        private TimeSpan AdjustDuration(Percentage OtherFill, TimeSpan Duration)
        {
            return new TimeSpan(0, 0, (int)(Duration.TotalSeconds * OtherFill.Percent));
        }

        private int AdjustValue(Percentage OtherFill, int value)
        {
            return (int)(value * OtherFill.Percent);
        }

        public Potion Separate(Percentage OtherFill)
        {

            if (OtherFill.Value > Fill.Value)
            {
                throw new InvalidOperationException("Cannot separate a potion by taking more than what it currently holds");
            }

            if (OtherFill.Value == Fill.Value)
            {
                throw new InvalidOperationException("Cannot separate a potion by taking the same amount that it currently holds. (Just take the potion itself.)");
            }

            Fill = new Percentage(Fill.Value - OtherFill.Value);

            List<Effect> fx = new List<Effect>();
            List<Effect> tfx = new List<Effect>();
            foreach (Effect e in Effects)
            {
                fx.Add(
                    new Effect()
                    {
                        Description = e.Description,
                        Duration = AdjustDuration(OtherFill, e.Duration),
                        Bonus = AdjustBonus(OtherFill, e.Bonus)
                    }
                    );
                tfx.Add(
                    new Effect()
                    {
                        Description = e.Description,
                        Duration = AdjustDuration(Fill, e.Duration),
                        Bonus = AdjustBonus(Fill, e.Bonus)
                    }
                    );
            }

            Effects = tfx;
            Value = new PriceTag(AdjustValue(Fill, Value.NumericalValue));

            return new Potion()
            {
                Effects = fx,
                Fill = OtherFill,
                Value = new PriceTag(AdjustValue(OtherFill, Value.NumericalValue))
            };

        }

        public void Dilute(Percentage newfill)
        {
            Fill = new Percentage(Fill.Value + newfill.Value);
            Value = new PriceTag((int)(Value.NumericalValue * (Fill.Percent - Solvent.Percent)));
        }
    }
}
