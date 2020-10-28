using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    public interface ICharacterProperty
    {
        int BasePoints { get; }
        int Bonus { get; }

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        int EffectPoints { get; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        int Total { get; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        int BaseTotal { get; }
    }
}
