using System;
using System.Collections.Immutable;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Linq;
using DiegoG.Utilities.Settings;
using System.Collections.Generic;

namespace DiegoG.DnDNetCore
{
    public static class Enumerations
    {
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
        public static IEnumerable<string> AlignmentsCollection
            => from str in (Alignments[])Enum.GetValues(typeof(Alignments)) select Settings<Lang>.Current.AlignmentStrings[str];

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
        public static IEnumerable<string> BodyTypesCollection
            => from str in (BodyTypes[])Enum.GetValues(typeof(BodyTypes)) select Settings<Lang>.Current.BodyTypeStrings[str];

        [Serializable]
        public enum CombatState
        {
            Active, Incapacitated, BleedingOut, Deceased
        }

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
        public static int StatCount => Enum.GetNames(typeof(Stats)).Length;
        public static IEnumerable<string> StatsCollection
            => from str in (Stats[])Enum.GetValues(typeof(Stats)) select Settings<Lang>.Current.StatsStrings[str];

        [Serializable, JsonConverter(typeof(JsonStringEnumConverter))]
        public enum SecondaryStats
        {
            [EnumMember(Value = "Speed")]
            Speed,

            [EnumMember(Value = "Initiative")]
            Initiative
        }
        public static IEnumerable<string> SecondaryStatsCollection
            => from str in (SecondaryStats[])Enum.GetValues(typeof(SecondaryStats)) select Settings<Lang>.Current.SecondaryStatsStrings[str];

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
        public static IEnumerable<string> SavingThrowCollection
            => from str in (SavingThrow[])Enum.GetValues(typeof(SavingThrow)) select Settings<Lang>.Current.SavingThrowStrings[str];
        public static int SavingThrowCount => Enum.GetNames(typeof(SavingThrow)).Length;

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
        public static IEnumerable<string> CombatActionCollection
            => from str in (CombatAction[])Enum.GetValues(typeof(CombatAction)) select Settings<Lang>.Current.CombatActionStrings[str];

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
        public static IEnumerable<string> MagicSchoolCollection
            => from str in (MagicSchool[])Enum.GetValues(typeof(MagicSchool)) select Settings<Lang>.Current.MagicSchoolStrings[str];
        public static int SchoolCount => Enum.GetNames(typeof(MagicSchool)).Length;

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
        public static IEnumerable<string> SizesCollection
            => from str in (Sizes[])Enum.GetValues(typeof(Sizes)) select Settings<Lang>.Current.SizeStrings[str];
        public static int SizeCount => Enum.GetNames(typeof(Sizes)).Length;
    }
}