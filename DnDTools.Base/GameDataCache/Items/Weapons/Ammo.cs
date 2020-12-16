using DiegoG.DnDTools.Base.Items.Weapons;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using DiegoG.DnDTools.Base.Items.Info;
using static DiegoG.DnDTools.Base.Enumerations;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;
using DiegoG.Utilities.Collections;

namespace DiegoG.DnDTools.Base.Cache.Items.Weapons
{
    public static class Ammunition
    {
        public static IEnumerable<Ammo> All { get; } = ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyValues<Ammo>(typeof(Ammunition));
        private static Lang SetLang => Settings<Lang>.Current;
        public static Ammo CrossbowBolt => new Ammo()
        {
            Name = SetLang.CrossbowBolt.Name,
            Value = new PriceTag(100),
            Weight = new Mass(0.1M, Mass.Units.Kilogram),
            Category = WeaponCategory.Improvised,
            ExtraRange = Length.Zero,
            AttackThrow = new AttackThrow(Stats.Strength),
            Damage = new AttackDamage(),
            Critical = new CriticalHit(0,0,0),
            Description = SetLang.CrossbowBolt.Description,
            Impact = ImpactType.Piercing,
            Encumbrance = ItemEncumbrance.Light
        };
        public static Ammo ThrowingKnife => new Ammo()
        {
            Name = SetLang.ThrowingKnife.Name,
            Value = new PriceTag(50),
            Weight = new Mass(0.1M, Mass.Units.Kilogram),
            Category = WeaponCategory.Simple,
            ThrownRangeIncrement = new Length(20, Length.Units.Foot),
            ExtraRange = Length.Zero,
            AttackThrow = new AttackThrow(Stats.Dexterity),
            Damage = new(null, null, null, null, "1d4", null, null, null, null),
            Critical = new CriticalHit(20, 2, 20),
            Description = SetLang.ThrowingKnife.Description,
            Impact = ImpactType.Piercing | ImpactType.Slashing
        };
    }
}
