using DiegoG.DnDTDesktop.Properties;
using System;
using System.Collections.Immutable;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using static System.Windows.Forms.CheckedListBox;

namespace DiegoG.DnDTDesktop
{
    public static class Enumerations
    {
        [Serializable, JsonConverter(typeof(JsonStringEnumMemberConverter))]
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

        [Serializable, JsonConverter(typeof(JsonStringEnumMemberConverter))]
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

        [Serializable]
        public enum CombatState
        {
            Active, Incapacitated, BleedingOut, Deceased
        }

        [Serializable]
        public enum Verbosity
        {
            None, Debug, Verbose
        }

        [Serializable, JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
        public static int StatCount { get; } = Enum.GetNames(typeof(Stats)).Length;

        [Serializable, JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum SecondaryStats
        {
            [EnumMember(Value = "Speed")]
            Speed,

            [EnumMember(Value = "Initiative")]
            Initiative
        }

        [Serializable, JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum SavingThrowsInitiative
        {
            [EnumMember(Value = "Fortitude")]
            Fortitude,

            [EnumMember(Value = "Reflexes")]
            Reflexes,

            [EnumMember(Value = "Willpower")]
            Willpower,

            [EnumMember(Value = "Initiative")]
            Initiative
        }
        public static int SavingThrowCount { get; } = Enum.GetNames(typeof(SavingThrowsInitiative)).Length;

        [Serializable, JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public enum Schools
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
        public static int SchoolCount { get; } = Enum.GetNames(typeof(Schools)).Length;

        [Serializable, JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
        public static int SizeCount { get; } = Enum.GetNames(typeof(Sizes)).Length;

        public static ImmutableDictionary<Stats, string> ShortStatNames { get; private set; }
        public static ObjectCollection TypeList { get; private set; }
        public static ObjectCollection SizeList { get; private set; }
        public static ObjectCollection AlignmentList { get; private set; }
        public static ObjectCollection StatList { get; private set; }

        static Enumerations()
        {
            var builder = ImmutableDictionary.CreateBuilder<Stats, string>();
            builder.Add(Stats.Charisma, "Cha");
            builder.Add(Stats.Constitution, "Con");
            builder.Add(Stats.Dexterity, "Dex");
            builder.Add(Stats.Intelligence, "Int");
            builder.Add(Stats.Strength, "Str");
            builder.Add(Stats.Wisdom, "Wis");
            foreach (var i in Enum.GetNames(typeof(BodyTypes)))
                TypeList.Add(Resources.ResourceManager.GetString(i));
            foreach (var i in Enum.GetNames(typeof(Sizes)))
                SizeList.Add(Resources.ResourceManager.GetString(i));
            foreach (var i in Enum.GetNames(typeof(Alignments)))
                AlignmentList.Add(Resources.ResourceManager.GetString(i));
            foreach (var i in Enum.GetNames(typeof(Stats)))
                StatList.Add(Resources.ResourceManager.GetString(i));
        }

    }
}