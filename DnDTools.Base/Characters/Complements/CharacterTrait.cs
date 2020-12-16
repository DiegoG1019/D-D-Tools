using DiegoG.Utilities.IO;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    [Serializable]
    public abstract class CharacterTrait<T> where T : class
    {
        public string ParentName { get; set; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public Character Parent => DnDManager.Characters[ParentName];
        public virtual T Copy() => (T)Serialization.CopyByBinarySerialization(this);
    }
}
