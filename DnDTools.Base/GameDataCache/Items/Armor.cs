using DiegoG.DnDTools.Base.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using static DiegoG.DnDTools.Base.Enumerations;
using DiegoG.Utilities.Collections;

namespace DiegoG.DnDTools.Base.Cache.Items
{
    public static class Armors
    {
        public static IEnumerable<Armor> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Armor>(typeof(Armors));
        private static Lang SetLang => Settings<Lang>.Current;
        public static Armor LeatherArmor => new Armor()
        {
            Name = SetLang.LeatherArmor.Name,
            Value = new PriceTag(1000),
            ThrownRangeIncrement = new Length(10, Length.Units.Inch),
            Protection = 2,
            MaximumDeterity = 7,
            Weight = new Mass(2, Mass.Units.Kilogram),
            Description = SetLang.LeatherArmor.Description,
            Encumbrance = ItemEncumbrance.TwoHand,
        };
    }
}
