using DiegoG.DnDTools.Base.Cache.Items.Weapons;
using DiegoG.DnDTools.Base.Items;
using DiegoG.DnDTools.Base.Items.Weapons;
using DiegoG.Utilities;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.Measures;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Cache.Items
{
    public static class OtherItems
    {
        public static IEnumerable<Item> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Item>(typeof(OtherItems));

        //All the private properties here exist because of how often they're repeated

        private static Lang Lang => Settings<Lang>.Current;
        private static Lang.ItemsLang ItemLang => Settings<Lang>.Current.Items;
        private static Length FiveFeet => new(5, Length.Units.Foot);
        private static Density WaterDensity => new(Mass.OneKilogram, Volume.OneLiter);

        public static Item Caltrops => new(ItemLang.Caltrops)
        {
            Encumbrance = ItemEncumbrance.Light,
            ThrownRangeIncrement = FiveFeet,
            Weight = new(2, Mass.Units.Pound),
            Value = new(1000)
        };
        public static Item Candle => new(ItemLang.Candle)
        {
            Encumbrance = ItemEncumbrance.Light,
            ThrownRangeIncrement = FiveFeet,
            Weight = new(100, Mass.Units.Gram),
            Value = new(1),
        };
        public static Melee Crowbar => new(ItemLang.Crowbar)
        {
            Weight = new(5, Mass.Units.Pound),
            Value = new(2000),
            Category = WeaponCategory.Improvised,

            Reach = MeleeWeapons.MetalClub.Reach,
            Damage = MeleeWeapons.MetalClub.Damage,
            Impact = MeleeWeapons.MetalClub.Impact,
            Critical = MeleeWeapons.MetalClub.Critical,
            Encumbrance = MeleeWeapons.MetalClub.Encumbrance,
            AttackThrow = MeleeWeapons.MetalClub.AttackThrow,
            ThrownRangeIncrement = MeleeWeapons.MetalClub.ThrownRangeIncrement,
        };
        public static Item FlintSteel => new(ItemLang.FlintSteel)
        {
            Weight = new(250, Mass.Units.Gram),
            Value = new(1000),
            Encumbrance = ItemEncumbrance.Light,
            ThrownRangeIncrement = FiveFeet,
        };
        public static Item GrapplingHook => new(ItemLang.GrapplingHook)
        {
            Weight = new(4, Mass.Units.Pound),
            Value = new(1000),
            Encumbrance = ItemEncumbrance.OneHand,
            ThrownRangeIncrement = new Length(10, Length.Units.Foot)
        };
        public static Melee Hammer => new(ItemLang.Hammer)
        {
            Weight = new(2, Mass.Units.Pound),
            Value = new(5000),
            Encumbrance = ItemEncumbrance.OneHand,
            ThrownRangeIncrement = FiveFeet,
            Damage = MeleeWeapons.SpikedGauntlet.Damage,
            AttackThrow = new(Stats.Strength),
            Reach = Length.OneSquare,
            Category = WeaponCategory.Improvised,
            Critical = new(20, 2, 20),
            Impact = ImpactType.Bludgeoning
        };
        public static Liquid Water => new(ItemLang.Water)
        {
            Density = WaterDensity,
            Amount = Volume.OneLiter,
            Value = new(10)
        };
        public static Liquid BlackInk => new(ItemLang.BlackInk)
        {
            Density = WaterDensity,
            Amount = Volume.OneOunce,
            Value = new(800)
        };
        public static Liquid ColoredInk => new(ItemLang.ColoredInk)
        {
            Density = WaterDensity,
            Amount = Volume.OneOunce,
            Value = new(1600)
        };
        public static Bottle ClayJug => new(ItemLang.ClayJug)
        {
            Value = new(9),
            BottleSize = Volume.OneGallon,
            BottleWeight = new(9, Mass.Units.Pound),
            Encumbrance = ItemEncumbrance.OneHand,
            ThrownRangeIncrement = FiveFeet
        };
        public static Item LampCommon => new(ItemLang.CommonLamp)
        {
            Value = new(10),
            Weight = new(1, Mass.Units.Pound),
            Encumbrance = ItemEncumbrance.OneHand,
            ThrownRangeIncrement = FiveFeet
        };
        public static Item LanternBullseye => new(ItemLang.BullseyeLantern)
        {
            Value = new(1200),
            Weight = new(3, Mass.Units.Pound),
            Encumbrance = ItemEncumbrance.OneHand,
            ThrownRangeIncrement = FiveFeet
        };
        public static Item LanternHooded => new(ItemLang.HoodedLantern)
        {
            Value = new(700),
            Weight = new(2, Mass.Units.Pound),
            Encumbrance = ItemEncumbrance.OneHand,
            ThrownRangeIncrement = FiveFeet
        };
        public static Item LockSimple => new(ItemLang.Lock)
        {
            Name = ItemLang.Lock.Name.Format(Lang.Other.SimpleText),
            Description = ItemLang.Lock.Description.Format(20),
            Value = new(2000),
            Weight = Mass.OnePound,
            Encumbrance = ItemEncumbrance.Light,
            ThrownRangeIncrement = FiveFeet,
        };
        public static Item LockAverage => new(ItemLang.Lock)
        {
            Name = ItemLang.Lock.Name.Format(Lang.Other.AverageText),
            Description = ItemLang.Lock.Description.Format(25),
            Value = new(4000),
            Weight = Mass.OnePound,
            Encumbrance = ItemEncumbrance.Light,
            ThrownRangeIncrement = FiveFeet,
        };
        public static Item LockGood => new(ItemLang.Lock)
        {
            Name = ItemLang.Lock.Name.Format(Lang.Other.GoodText),
            Description = ItemLang.Lock.Description.Format(30),
            Value = new(8000),
            Weight = Mass.OnePound,
            Encumbrance = ItemEncumbrance.Light,
            ThrownRangeIncrement = FiveFeet,
        };
        public static Item LockSuperior => new(ItemLang.Lock)
        {
            Name = ItemLang.Lock.Name.Format(Lang.Other.SuperiorText),
            Description = ItemLang.Lock.Description.Format(40),
            Value = new(15000),
            Weight = Mass.OnePound,
            Encumbrance = ItemEncumbrance.Light,
            ThrownRangeIncrement = FiveFeet,
        };
        public static Liquid Oil => new(ItemLang.Oil)
        {
            Density = new(0.8M, Mass.Units.Kilogram, Volume.Units.Liter),
            Amount = Volume.OnePint,
            Value = new(10)
        };
        public static Item RamPortable => new(ItemLang.Oil)
        {
            Value = new(10000),
            Weight = new(20, Mass.Units.Pound),
            Encumbrance = ItemEncumbrance.TwoHand,
            ThrownRangeIncrement = Length.OneFoot,
        };
        public static Bottle Vial => new(ItemLang.Vial)
        {
            Value = new(100),
            BottleWeight = new(1 / 10M, Mass.Units.Pound),
            Encumbrance = ItemEncumbrance.Light,
            ThrownRangeIncrement = FiveFeet,
            BottleSize = Volume.OneOunce,
        };
    }
}
