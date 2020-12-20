using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DiegoG.DnDTools.Base
{
    public static class Enumerations
    {
        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum WeaponCategory
        {

            [EnumMember(Value = "Simple")]
            Simple,

            [EnumMember(Value = "Martial")]
            Martial,

            [EnumMember(Value = "Exotic")]
            Exotic,

            [EnumMember(Value = "Improvised")]
            Improvised
        }
        public static IEnumerable<string> WeaponCategoryStringCollection
            => from str in WeaponCategoryCollection select Settings<Lang>.Current.WeaponCategoryStrings[str];
        public static IEnumerable<WeaponCategory> WeaponCategoryCollection
        { get; } = from str in (WeaponCategory[])Enum.GetValues(typeof(WeaponCategory)) select str;

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ImpactType
        {
            [EnumMember(Value = "Bludgeoning")]
            Bludgeoning = 0b0001,

            [EnumMember(Value = "Slashing")]
            Slashing = 0b0010,

            [EnumMember(Value = "Piercing")]
            Piercing = 0b0100
        }
        public static IEnumerable<string> ImpactTypeStringCollection
            => from str in ImpactTypeCollection select Settings<Lang>.Current.ImpactTypeStrings[str];
        public static IEnumerable<ImpactType> ImpactTypeCollection
        { get; } = from str in (ImpactType[])Enum.GetValues(typeof(ImpactType)) select str;

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ItemEncumbrance
        {
            [EnumMember(Value = "Light")]
            Light,

            [EnumMember(Value = "One Handed")]
            OneHand,

            [EnumMember(Value = "Two Handed")]
            TwoHand
        }
        public static IEnumerable<string> ItemEncumbranceStringCollection
            => from str in ItemEncumbranceCollection select Settings<Lang>.Current.ItemEncumbranceStrings[str];
        public static IEnumerable<ItemEncumbrance> ItemEncumbranceCollection
        { get; } = from str in (ItemEncumbrance[])Enum.GetValues(typeof(ItemEncumbrance)) select str;

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Alignments
        {
            [EnumMember(Value = "Chaotic Evil")]
            ChaoticEvil,

            [EnumMember(Value = "Neutral Evil")]
            NeutralEvil,

            [EnumMember(Value = "Lawful Evil")]
            LawfulEvil,

            [EnumMember(Value = "Chaotic Neutral")]
            ChaoticNeutral,

            [EnumMember(Value = "True Neutral")]
            TrueNeutral,

            [EnumMember(Value = "Lawful Neutral")]
            LawfulNeutral,

            [EnumMember(Value = "Chaotic Good")]
            ChaoticGood,

            [EnumMember(Value = "Neutral Good")]
            NeutralGood,

            [EnumMember(Value = "Lawful Good")]
            LawfulGood
        }
        public static IEnumerable<string> AlignmentsStringCollection
            => from str in AlignmentsCollection select Settings<Lang>.Current.AlignmentStrings[str];
        public static IEnumerable<Alignments> AlignmentsCollection
        { get; } = from str in (Alignments[])Enum.GetValues(typeof(Alignments)) select str;

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum BodyTypes
        {
            [EnumMember(Value = "Aberration")]
            Aberration,

            [EnumMember(Value = "Animal")]
            Animal,

            [EnumMember(Value = "Construct")]
            Construct,

            [EnumMember(Value = "Dragon")]
            Dragon,

            [EnumMember(Value = "Elemental")]
            Elemental,

            [EnumMember(Value = "Fey")]
            Fey,

            [EnumMember(Value = "Giant")]
            Giant,

            [EnumMember(Value = "Humanoid")]
            Humanoid,

            [EnumMember(Value = "MagicalBeast")]
            MagicalBeast,

            [EnumMember(Value = "MonstrousHumanoid")]
            MonstrousHumanoid,

            [EnumMember(Value = "Ooze")]
            Ooze,

            [EnumMember(Value = "Outsider")]
            Outsider,

            [EnumMember(Value = "Plant")]
            Plant,

            [EnumMember(Value = "Undead")]
            Undead,

            [EnumMember(Value = "Vermin")]
            Vermin
        }
        public static IEnumerable<string> BodyTypesStringCollection
            => from str in BodyTypesCollection select Settings<Lang>.Current.BodyTypeStrings[str];
        public static IEnumerable<BodyTypes> BodyTypesCollection
        { get; } = from str in (BodyTypes[])Enum.GetValues(typeof(BodyTypes)) select str;

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum CombatState
        {
            [EnumMember(Value = "Active")]
            Active,

            [EnumMember(Value = "Incapacitated")]
            Incapacitated,

            [EnumMember(Value = "BleedingOut")]
            BleedingOut,

            [EnumMember(Value = "Deceased")]
            Deceased
        }
        public static IEnumerable<string> CombatStateStringCollection
            => from str in CombatStateCollection select Settings<Lang>.Current.CombatStateStrings[str];
        public static IEnumerable<CombatState> CombatStateCollection
        { get; } = from str in (CombatState[])Enum.GetValues(typeof(CombatState)) select str;


        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Stats
        {
            [EnumMember(Value = "Strength")]
            Strength,

            [EnumMember(Value = "Constitution")]
            Constitution,

            [EnumMember(Value = "Dexterity")]
            Dexterity,

            [EnumMember(Value = "Wisdom")]
            Wisdom,

            [EnumMember(Value = "Intelligence")]
            Intelligence,

            [EnumMember(Value = "Charisma")]
            Charisma
        }
        public static IEnumerable<string> StatsStringCollection
            => from str in StatsCollection select Settings<Lang>.Current.StatsStrings[str];
        public static IEnumerable<string> ShortStatsStringCollection
            => from str in StatsCollection select Settings<Lang>.Current.ShortStatsStrings[str];
        public static IEnumerable<Stats> StatsCollection
        { get; } = from str in (Stats[])Enum.GetValues(typeof(Stats)) select str;
        public static int StatCount { get; } = StatsCollection.Count();


        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum SecondaryStats
        {
            [EnumMember(Value = "Speed")]
            Speed,

            [EnumMember(Value = "Initiative")]
            Initiative
        }
        public static IEnumerable<string> SecondaryStatsStringCollection
            => from str in SecondaryStatsCollection select Settings<Lang>.Current.SecondaryStatsStrings[str];
        public static IEnumerable<SecondaryStats> SecondaryStatsCollection
        { get; } = from str in (SecondaryStats[])Enum.GetValues(typeof(SecondaryStats)) select str;

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum SavingThrow
        {
            [EnumMember(Value = "Fortitude")]
            Fortitude,

            [EnumMember(Value = "Reflexes")]
            Reflexes,

            [EnumMember(Value = "Willpower")]
            Willpower
        }
        public static IEnumerable<string> SavingThrowStringCollection
            => from str in SavingThrowCollection select Settings<Lang>.Current.SavingThrowStrings[str];
        public static IEnumerable<SavingThrow> SavingThrowCollection
        { get; } = from str in (SavingThrow[])Enum.GetValues(typeof(SavingThrow)) select str;
        public static int SavingThrowCount { get; } = SavingThrowCollection.Count();

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum CombatAction
        {
            [EnumMember(Value = "Standard Action")]
            Standard,

            [EnumMember(Value = "Move Action")]
            Move,

            [EnumMember(Value = "Full Round Action")]
            FullRound,

            [EnumMember(Value = "Free Action")]
            Free,

            [EnumMember(Value = "Swift Action")]
            Swift,

            [EnumMember(Value = "Immediate Action")]
            Immediate,

            [EnumMember(Value = "Not an Action")]
            NotAnAction
        }
        public static IEnumerable<string> CombatActionStringCollection
            => from str in CombatActionCollection select Settings<Lang>.Current.CombatActionStrings[str];
        public static IEnumerable<CombatAction> CombatActionCollection
        { get; } = from str in (CombatAction[])Enum.GetValues(typeof(CombatAction)) select str;

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum MagicSchool
        {
            [EnumMember(Value = "Abjuration")]
            Abjuration,

            [EnumMember(Value = "Divination")]
            Divination,

            [EnumMember(Value = "Conjuration")]
            Conjuration,

            [EnumMember(Value = "Enchantment")]
            Enchantment,

            [EnumMember(Value = "Evocation")]
            Evocation,

            [EnumMember(Value = "Illusion")]
            Illusion,

            [EnumMember(Value = "Necromancy")]
            Necromancy,

            [EnumMember(Value = "Transmutation")]
            Transmutation
        }
        public static IEnumerable<string> MagicSchoolStringCollection
            => from str in MagicSchoolCollection select Settings<Lang>.Current.MagicSchoolStrings[str];
        public static IEnumerable<MagicSchool> MagicSchoolCollection
        { get; } = from str in (MagicSchool[])Enum.GetValues(typeof(MagicSchool)) select str;
        public static int SchoolCount { get; } = MagicSchoolCollection.Count();

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Sizes
        {
            [EnumMember(Value = "Fine")]
            Fine,

            [EnumMember(Value = "Diminutive")]
            Diminutive,

            [EnumMember(Value = "Tiny")]
            Tiny,

            [EnumMember(Value = "Small")]
            Small,

            [EnumMember(Value = "Medium")]
            Medium,

            [EnumMember(Value = "Large")]
            Large,

            [EnumMember(Value = "Huge")]
            Huge,

            [EnumMember(Value = "Gargantuan")]
            Gargantuan,

            [EnumMember(Value = "Colossal")]
            Colossal
        }
        public static IEnumerable<string> SizesStringCollection
            => from str in SizesCollection select Settings<Lang>.Current.SizeStrings[str];
        public static IEnumerable<Sizes> SizesCollection
        { get; } = from str in (Sizes[])Enum.GetValues(typeof(Sizes)) select str;
        public static int SizeCount { get; } = SizesCollection.Count();
    }
}