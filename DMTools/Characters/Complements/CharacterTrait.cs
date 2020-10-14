using DiegoG.Utilities;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    [Serializable]
    public abstract class CharacterTrait<T> where T : class
    {
        public string ParentName { get; set; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public Character Parent => Program.Characters[ParentName];
        public virtual T Copy() => (T)Serialization.CopyByBinarySerialization(this);
    }
}
