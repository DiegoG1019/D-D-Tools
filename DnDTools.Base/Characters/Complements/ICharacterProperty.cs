using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    public interface ICharacterProperty : INotifyPropertyChanged
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