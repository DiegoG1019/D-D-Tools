using DiegoG.DnDTDesktop.Properties;
using System;
using System.Collections.Immutable;
using static System.Windows.Forms.CheckedListBox;

namespace DiegoG.DnDTDesktop
{
    public static class Enums
    {
        [Serializable]
        public enum Alignments
        {
            ChaoticEvil, NeutralEvil, LawfulEvil,
            ChaoticNeutral, TrueNeutral, LawfulNeutral,
            ChaoticGood, NeutralGood, LawfulGood
        }
        [Serializable]
        public enum BodyTypes
        {
            Aberration, Animal, Construct, Dragon, Elemental, Fey, Giant, Humanoid,
            MagicalBeast, MonstrousHumanoid, Ooze, Outsider, Plant, Undead, Vermin
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
        [Serializable]
        public enum Stats
        {
            Strength, Constitution, Dexterity, Wisdom, Intelligence, Charisma
        }
        public static int StatCount { get; } = Enum.GetNames(typeof(Stats)).Length;

        public enum SecondaryStats
        {
            Speed, Initiative
        }

        [Serializable]
        public enum SavingThrows
        {
            Fortitude, Reflexes, Willpower
        }
        public static int SavingThrowCount { get; } = Enum.GetNames(typeof(SavingThrows)).Length;

        [Serializable]
        public enum Schools
        {
            Abjuration, Divination, Conjuration, Enchantment, Evocation, Illusion, Necromancy, Transmutation
        }
        public static int SchoolCount { get; } = Enum.GetNames(typeof(Schools)).Length;

        [Serializable]
        public enum Sizes
        {
            Fine, Diminutive, Tiny, Small, Medium, Large, Huge, Gargantuan, Colossal
        }
        public static int SizeCount { get; } = Enum.GetNames(typeof(Sizes)).Length;


        public static ImmutableDictionary<Stats, string> ShortStatNames { get; private set; }
        public static ObjectCollection TypeList { get; private set; }
        public static ObjectCollection SizeList { get; private set; }
        public static ObjectCollection AlignmentList { get; private set; }
        public static ObjectCollection StatList { get; private set; }

        static Enums()
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