using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using DiegoG.DnDTools.Base.Scripting;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    public class SecondaryCharacterStatProperty : CharacterTrait<SecondaryCharacterStatProperty>, ICharacterProperty
    {
        public int BasePoints { get; set; }
        public int Bonus { get; set; }
        public int EffectPoints { get; set; }
        public CharacterPropertyScript ScriptData { get; set; }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int BaseTotal => BasePoints + Bonus + DependentValue;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Total => BaseTotal + EffectPoints;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int Modifier => (Total / 2) - 5;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int BaseModifier => (BaseTotal / 2) - 5;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public bool HasScript => ScriptData != null;
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int DependentValue => (HasScript ? ScriptData.DependentValue(Parent, this) : 0);
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public int OtherValue => (HasScript ? ScriptData.OtherValue(Parent, this) : 0);
    }
}
