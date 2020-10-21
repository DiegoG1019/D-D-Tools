using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    public class CharacterSecondaryStatProperty : CharacterTrait<CharacterSecondaryStatProperty>, ICharacterProperty
    {
        public int BasePoints { get; set; }
        public int Bonus { get; set; }
        public int EffectPoints { get; set; }
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int BaseTotal => BasePoints + Bonus + Parent.Stats[Stats.Dexterity].Modifier;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Total => BaseTotal + EffectPoints;
    }
}