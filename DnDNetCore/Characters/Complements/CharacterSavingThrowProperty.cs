using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.Characters.Complements
{
    [Serializable]
    public class CharacterSavingThrowProperty : CharacterTrait<CharacterSavingThrowProperty>, ICharacterProperty
    {
        public Stats BaseStat { get; set; }
        public int BasePoints { get; set; }
        public int Bonus { get; set; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int EffectPoints { get; set; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int BaseTotal => BasePoints + Parent.Stats[BaseStat].Total + Bonus;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public int Total => BaseTotal + EffectPoints;
    }
}
