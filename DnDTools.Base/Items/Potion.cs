using DiegoG.DnDNetCore.Items.Info;
using DiegoG.DnDNetCore.Other;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.Items
{
    [Serializable]
    public class Potion : Item
    {
        public class Liquid : IDescribableItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public PriceTag Value { get; set; }
            public NoteList Notes { get; set; } = new();
            public Density LiquidDensity { get; set; } = new(1);
            public List<Effect> Effects { get; set; } = new List<Effect>();
            public Percentage Fill { get; set; } = new(100);
        }

        public Volume FlaskSize { get; set; } = new(10, Volume.Units.Ounce);
        public Mass FlaskMass { get; set; } = new(300, Mass.Units.Gram);
        public List<Liquid> Liquids { get; set; } = new();
        public bool IsFull => Fill.Value == 100d;
        public bool IsOverFilled => Fill.Value > 100d;
        public Percentage Fill
        {
            get
            {
                double a = 0;
                foreach (var l in Liquids)
                    a += l.Fill.Value;
                return new(a);
            }
        }
        public Potion() { }
        public Potion(NameDesc nameDesc) : base(nameDesc) { }
    }
}
