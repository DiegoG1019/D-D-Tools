using DiegoG.DnDNetCore.Characters.Complements;
using static DiegoG.DnDNetCore.Enumerations;
using DiegoG.DnDNetCore.Other;
using System.Collections.Generic;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;

namespace DiegoG.DnDNetCore.Characters.Cache
{
    public static class Abilities
    {
        public static Ability SneakAttack => new Ability()
        {
            Name = "Sneak Attack",
            Description = "If the Victim cannot benefit from their Dexterity in their AC, or is being flanked by this character, the Victim is subject to a sneak attack",
            Notes = new NoteList()
            {
                "Refer to \"Sneak Attack\" as a weapon",
            }
        };
        public static Ability Trapfinding => new Ability()
        {
            Name = "Trapfinding",
            Description = "Can find (look for) a trap with a CD > 20; or a magical tramp with a CD of 25+ Spell Level. Can neutralize Magical traps. If the throw is 10 above the required CD the trap can be re-armed in the character's favour",
        };
        public static Ability DarkVision => new Ability()
        {
            Name = "Dark Vision",
            Description = $"Can see situations with little light with full color, in a {new Length(60, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit, "0.00")} radius"
        };
        public static Ability Evasion => new Ability()
        {
            Name = "Evasion",
            Description = "A succesful Reflexes ST against a magical attack results in no damage being received",
            Tags = new List<Ability.AbilityTag>()
            {
                Ability.AbilityTag.Extraordinary
            }
        };
        public static Ability TrapSense => new Ability()
        {
            Name = "Trap Sense",
            Description = "Receives a bonifier to Reflexes STs against traps, as well as a bonifier to CA to avoid attacks of the same source, per level of Trap Sense",
            Level = 1,
            Tags = new List<Ability.AbilityTag>()
            {
                Ability.AbilityTag.Extraordinary
            },
            Notes = new NoteList()
            {
                "It's an intuitive sense"
            }
        };
        public static Ability SummonFamiliar => new Ability()
        {
            Name = "Summon Familiar",
            Description = "The character is able to summon a familiar from a living animal. Can only summon one at a time after a summoning ritual.",
            Notes = new NoteList()
            {
                "The Familiar becomes a part of the Character's soul",
                "The animal must be familiar and emotionally attached to the user before it can be a familiar candidate",
                "The animal must be willing to become the user's familiar"
            }
        };
        public static Ability ReadMagic => new Ability()
        {
            Name = "Read Magic",
            Description = "The Character is able to read magical scrolls and spell books. As well as other magical writings that are written in a known magical language."
        };
        public static Ability MixedBlood => new Ability()
        {
            Name = "Mixed Blood: A, B",
            Description = "Can be considered either or both of these races at any given time",
        };
        public static Ability UncannyDodge => new Ability()
        {
            Name = "Uncanny Dodge",
            Description = "The character retains their Dexterity bonus to AC in any situation, even if caught flat-footed. The only exception is when the character is immobilization.",
            Tags = new List<Ability.AbilityTag>()
            {
                Ability.AbilityTag.Extraordinary
            }
        };
        public static Ability ImprovedUncannyDodge => new Ability()
        {
            Name = "Improved Uncanny Dodge",
            Description = "The character retains their Dexterity bonus to AC in any situation, Immobilization halves the bonus. The character can only be flanked by a Rogue at least four levels higher",
            Tags = new List<Ability.AbilityTag>()
            {
                Ability.AbilityTag.Extraordinary
            }
        };
        public static Ability Insomnia => new Ability()
        {
            Name = "Insomnia",
            Description = "The character is completely immune to sleeping effects, and receives a racial +2 against enchanting effects"
        };
        public static Ability ElvenSenses => new Ability()
        {
            Name = "Elven Senses",
            Description = "The Character gains a +1 to: \"Spot\", \"Search\" and \"Listen\""
        };
        public static Ability GoodRelations => new Ability()
        {
            Name = "Good Relations",
            Description = "The Character gains a +2 to: \"Diplomacy\" and \"Gather Information\""
        };
    }
}
