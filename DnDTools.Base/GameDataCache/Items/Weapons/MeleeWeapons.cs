﻿using DiegoG.DnDTools.Base.Items.Weapons;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.Measures;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;
using static DiegoG.DnDTools.Base.Enumerations;
using static DiegoG.DnDTools.Base.Lang;

namespace DiegoG.DnDTools.Base.Cache.Items.Weapons
{
    public static class MeleeWeapons
    {
        public static IEnumerable<Melee> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Melee>(typeof(MeleeWeapons));
        private static WeaponsAndArmorLang SetLang => Settings<Lang>.Current.WeaponsAndArmor;
        public static Melee MetalClub => new(SetLang.Club)
        {
            AttackThrow = new(Stats.Strength),
            Damage = new("1d1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6"),
            ThrownRangeIncrement = new(10, Length.Units.Foot),
            Category = WeaponCategory.Simple,
            Critical = new(20, 2, 20),
            Encumbrance = ItemEncumbrance.OneHand,
            Impact = ImpactType.Bludgeoning,
            Reach = new(1, Length.Units.Square),
            Weight = new(3, Mass.Units.Pound),
            Value = new(1000)
        };
        public static Melee SpikedGauntlet => new(SetLang.SpikedGauntlet)
        {
            AttackThrow = new(Stats.Strength),
            Damage = new("1d1", "1d1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6"),
            ThrownRangeIncrement = new(5, Length.Units.Foot),
            Category = WeaponCategory.Simple,
            Critical = new(20, 2, 20),
            Encumbrance = ItemEncumbrance.TwoHand,
            Impact = ImpactType.Piercing,
            Reach = Length.OneSquare,
            Weight = new(1, Mass.Units.Pound),
            Value = new(5000)
        };
    }
}
