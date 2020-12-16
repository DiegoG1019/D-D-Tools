using DiegoG.DnDTools.Base.Items.Info;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items
{
    [Serializable]
    public class Bottle : Item
    {
        public Volume BottleSize { get; set; } = new(10, Volume.Units.Ounce);
        public Mass BottleWeight { get; set; } = new(300, Mass.Units.Gram);
        public override Mass Weight { get => base.Weight; }
        public List<(Liquid Liquid, Percentage Fill)> Liquids { get; set; } = new();
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
        public Bottle() { }
        public Bottle(NameDesc nameDesc) : base(nameDesc) { }
    }
}
