using System;

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
            Strength, Constitution, Dexterity, Wisdom, Intelligence, Charisma,
            Speed, Initiative
        }
        public static int StatCount { get; } = Enum.GetNames(typeof(Stats)).Length;

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
    }
}