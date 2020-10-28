using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Other;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public sealed class Ability : CharacterTrait<Ability>, INoted
    {
        public struct AbilityTag
        {
            public string Name { get; set; }
            public string ShortenedName { get; set; }
            public string Description { get; set; }

            public static AbilityTag Extraordinary = new AbilityTag()
            {
                Name = "Extraordinary Ability",
                ShortenedName = "Ex.",
                Description = "Extraordinary abilities are nonmagical, though they may break the laws of physics. They are not something that just anyone can do or even learn to do without extensive training."
            };
            public static AbilityTag SpellLike = new AbilityTag()
            {
                Name = "Spell-Like Ability",
                ShortenedName = "Sp",
                Description = "Usually, a spell-like ability works just like the spell of that name. A few spell-like abilities are unique; these are explained in the text where they are described."
            };
            public static AbilityTag Supernatural = new AbilityTag()
            {
                Name = "Supernatural Ability",
                ShortenedName = "Su",
                Description = "Supernatural abilities are magical and go away in an antimagic field but are not subject to spell resistance, counterspells, or to being dispelled by dispel magic."
            };
        }

        public string Name { get; set; }
        public string Requirements { get; set; } = "None.";
        public string Description { get; set; }
        /// <summary>
        /// Not always applicable
        /// </summary>
        public int Level { get; set; } = 0;
        public NoteList Notes { get; set; } = new NoteList();
        public int[] Buffs { get; set; } = new int[Enumerations.StatCount];
        public List<AbilityTag> Tags { get; set; } = new List<AbilityTag>();

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public string FullName
        {
            get
            {
                string str = Name + (Level > 0 ? $"+{Level}" : "");
                foreach (AbilityTag tag in Tags)
                    str += $" ({tag.ShortenedName})";
                return str;
            }
        }

    }
}
