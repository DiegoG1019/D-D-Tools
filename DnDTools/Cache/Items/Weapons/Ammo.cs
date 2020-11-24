using DiegoG.DnDNetCore.Items.Weapons;
using DiegoG.DnDNetCore.Other;
using DiegoG.Utilities;
using DiegoG.DnDNetCore.Items.Info;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.Cache.Items.Weapons
{
    public static class Ammunition
    {
        private static AttackDamage ThrowingKnifeDamage
        {
            get
            {
                var a = new AttackDamage();
                a[Sizes.Medium] = new Dice("1d4");
                return a;
            }
        }
        public static Ammo CrossbowBolt => new Ammo()
        {
            Name = "Crossbow Bolts",
            Value = new PriceTag(100),
            Weight = new Mass(0.1M, Mass.Units.Kilogram),
            Type = "Light",
            RangeIncrement = Length.Zero,
            AttackThrow = new AttackThrow(Stats.Dexterity),
            Damage = new AttackDamage(),
            Critical = new CriticalHit(0,0,0),
            Description = "A common, well-made bolt used for crossbows",
            Impact = "Piercing",
        };
        public static Ammo ThrowingKnife => new Ammo()
        {
            Name = "Throwing Knife",
            Value = new PriceTag(50),
            Weight = new Mass(0.1M, Mass.Units.Kilogram),
            Type = "Light",
            RangeIncrement = new Length(20, Length.Units.Foot),
            AttackThrow = new AttackThrow(Stats.Dexterity),
            Damage = ThrowingKnifeDamage,
            Critical = new CriticalHit(20, 2, 20),
            Description = "A common, well-made small knife made for throwing",
            Impact = "Cutting, Piercing",
        };
    }
}
