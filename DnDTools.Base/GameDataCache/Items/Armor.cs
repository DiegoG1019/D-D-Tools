using DiegoG.DnDTools.Base.Items;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.Measures;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;
using static DiegoG.DnDTools.Base.Enumerations;
using static DiegoG.DnDTools.Base.Lang;

namespace DiegoG.DnDTools.Base.Cache.Items
{
    public static class Armors
    {
        public static IEnumerable<Armor> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Armor>(typeof(Armors));
        private static WeaponsAndArmorLang SetLang => Settings<Lang>.Current.WeaponsAndArmor;
        public static Armor LeatherArmor => new Armor(SetLang.LeatherArmor)
        {
            Value = new PriceTag(1000),
            ThrownRangeIncrement = new Length(10, Length.Units.Inch),
            Protection = 2,
            MaximumDeterity = 7,
            Weight = new Mass(2, Mass.Units.Kilogram),
            Encumbrance = ItemEncumbrance.TwoHand,
        };
    }
}
