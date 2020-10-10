using System;

namespace DiegoG.DnDTDesktop
{
    public class Enums
    {
        public enum Alignments
        {
            ChaoticEvil, NeutralEvil, LawfulEvil,
            ChaoticNeutral, TrueNeutral, LawfulNeutral,
            ChaoticGood, NeutralGood, LawfulGood
        }
        public enum BodyTypes
        {
            Aberration, Animal, Construct, Dragon, Elemental, Fey, Giant, Humanoid,
            MagicalBeast, MonstrousHumanoid, Ooze, Outsider, Plant, Undead, Vermin
        }
        public enum CombatState
        {
            Active, Incapacitated, BleedingOut, Deceased
        }
        public enum Verbosity
        {
            None, Debug, Verbose
        }

        public enum Stats
        {
            Strength, Constitution, Dexterity, Wisdom, Intelligence, Charisma,
            Speed, Initiative
        }
        public static int StatCount { get; } = Enum.GetNames(typeof(Stats)).Length;

        public enum SavingThrows
        {
            Fortitude, Reflexes, Willpower
        }
        public static int SavingThrowCount { get; } = Enum.GetNames(typeof(SavingThrows)).Length;

        public enum Schools
        {
            Abjuration, Divination, Conjuration, Enchantment, Evocation, Illusion, Necromancy, Transmutation
        }
        public static int SchoolCount { get; } = Enum.GetNames(typeof(Schools)).Length;

        public enum Sizes
        {
            Fine, Diminutive, Tiny, Small, Medium, Large, Huge, Gargantuan, Colossal
        }
        public static int SizeCount { get; } = Enum.GetNames(typeof(Sizes)).Length;
    }
}