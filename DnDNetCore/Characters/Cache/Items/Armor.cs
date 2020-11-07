using DiegoG.DnDNetCore.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDNetCore.Other;
using DiegoG.Utilities;

namespace DiegoG.DnDNetCore.Characters.Cache.Items
{
    public static class Armors
    {
        public static Armor LeatherArmor => new Armor()
        {
            Name = "Leather Armor",
            Value = new PriceTag(1000),
            RangeIncrement = new Length(10, Length.Units.Inch),
            Protection = 2,
            MaximumDeterity = 7,
            Weight = new Mass(2, Mass.Units.Kilogram),
            Description = "A normal, well-made leather armor, offering a good amount of protection for relatively free movement.",
        };
    }
}
