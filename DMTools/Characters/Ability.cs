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
        }

        public string Name { get; set; }
        public string Requirements { get; set; }
        public string Description { get; set; }
        public NoteList Notes { get; set; }
        public int[] Buffs { get; set; }
        public List<AbilityTag> Tags { get; set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public string FullName
        {
            get
            {
                const string s = " ({0})";
                string str = String.Empty;
                foreach (AbilityTag tag in Tags)
                {
                    str += String.Format(s, tag.ShortenedName);
                }
                return str;
            }
        }

    }
}
